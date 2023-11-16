using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.LogViewer.JsonParser.Managers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Analogy.LogViewer.JsonParser
{
    public class JsonFileLoader
    {
        private JsonSettings JsonSettings { get; }
        public JsonFileLoader(JsonSettings jsonSettings)
        {
            JsonSettings = jsonSettings;
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                DateParseHandling = jsonSettings.DateParseHandling,
            };
        }

        public async Task<IEnumerable<IAnalogyLogMessage>> Process(string fileName, CancellationToken token,
            ILogMessageCreatedHandler messagesHandler)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                AnalogyLogMessage empty = new AnalogyLogMessage($"File is null or empty. Aborting.",
                    AnalogyLogLevel.Critical, AnalogyLogClass.General, "Analogy", "None")
                {
                    Source = "Analogy",
                    Module = System.Diagnostics.Process.GetCurrentProcess().ProcessName,
                };
                messagesHandler.AppendMessage(empty, Utils.GetFileNameAsDataSource(fileName));
                return new List<AnalogyLogMessage> { empty };
            }

            switch (JsonSettings.Format)
            {
                case FileFormat.Unknown:
                    AnalogyLogMessage empty = new AnalogyLogMessage($"File Format is unknown. Unable to read file",
                        AnalogyLogLevel.Critical, AnalogyLogClass.General, "Analogy", "None")
                    {
                        Source = "Analogy",
                        Module = System.Diagnostics.Process.GetCurrentProcess().ProcessName,
                    };
                    messagesHandler.AppendMessage(empty, Utils.GetFileNameAsDataSource(fileName));
                    return new List<AnalogyLogMessage> { empty };
                    break;
                case FileFormat.JsonFormatPerLine:
                    return ProcessJsonPerLine(fileName, token, messagesHandler);
                    break;
                case FileFormat.JsonFormatFile:
                    return ProcessJsonFile(fileName, token, messagesHandler);
                    break;
                default:
                    AnalogyLogMessage none = new AnalogyLogMessage($"Unknown file format", AnalogyLogLevel.Critical, AnalogyLogClass.General, "Analogy", "None")
                    {
                        Source = "Analogy",
                        Module = System.Diagnostics.Process.GetCurrentProcess().ProcessName,
                    };
                    messagesHandler.AppendMessage(none, Utils.GetFileNameAsDataSource(fileName));
                    return new List<AnalogyLogMessage> { none };
            }
        }

        private List<IAnalogyLogMessage> ProcessJsonFile(string fileName, CancellationToken token, ILogMessageCreatedHandler messagesHandler)
        {
            string json = File.ReadAllText(fileName);
            return ProcessJsonData(json, fileName, messagesHandler, true);
        }

        private List<IAnalogyLogMessage> ProcessJsonData(string json, string fileName, ILogMessageCreatedHandler messagesHandler, bool reportProgress)
        {
            List<IAnalogyLogMessage> messages = new();
            try
            {
                var items = JsonConvert.DeserializeObject<dynamic>(json);
                if (items is JArray jArray)
                {
                    for (var i = 0; i < jArray.Count; i++)
                    {
                        var item = jArray[i];
                        var itemProperties = item.Children<JProperty>().ToList();
                        List<(string, string)> tuples = new(itemProperties.Count);
                        List<(string, string)> nonAnalogyTuples = new(itemProperties.Count);

                        foreach (var jprop in itemProperties)
                        {
                            if (UserSettingsManager.UserSettings.Settings.TryGetAnalogyValue(jprop.Name, out var prop))
                            {
                                tuples.Add((prop.ToString(), jprop.Value.ToString()));
                            }
                            else
                            {
                                nonAnalogyTuples.Add((jprop.Name, jprop.Value.ToString()));
                            }
                        }

                        var m = AnalogyLogMessage.Parse(tuples);
                        m.RawText = item.ToString();
                        m.RawTextType = AnalogyRowTextType.JSON;
                        foreach (var t in nonAnalogyTuples)
                        {
                            m.AddOrReplaceAdditionalProperty(t.Item1, t.Item2);
                        }
                        messages.Add(m);
                        if (reportProgress)
                        {
                            messagesHandler.ReportFileReadProgress(new AnalogyFileReadProgress(AnalogyFileReadProgressType.Percentage, 1, i, jArray.Count));
                        }
                    }
                }
                else if (items is JObject jObject)
                {
                    var itemProperties = jObject.Children<JProperty>().ToList();
                    List<(string, string)> tuples = new List<(string, string)>(itemProperties.Count);
                    List<(string, string)> nonAnalogyTuples = new List<(string, string)>(itemProperties.Count);

                    foreach (var jprop in itemProperties)
                    {
                        if (UserSettingsManager.UserSettings.Settings.TryGetAnalogyValue(jprop.Name, out var prop))
                        {
                            tuples.Add((prop.ToString(), jprop.Value.ToString()));
                        }
                        else
                        {
                            nonAnalogyTuples.Add((jprop.Name, jprop.Value.ToString()));
                        }
                    }

                    var m = AnalogyLogMessage.Parse(tuples);
                    m.RawText = json;
                    m.RawTextType = AnalogyRowTextType.JSON;
                    foreach (var t in nonAnalogyTuples)
                    {
                        m.AddOrReplaceAdditionalProperty(t.Item1, t.Item2);
                    }
                    messages.Add(m);
                    if (reportProgress)
                    {
                        messagesHandler.ReportFileReadProgress(new AnalogyFileReadProgress(AnalogyFileReadProgressType.Percentage, 1, 1, 1));
                    }
                }
                messagesHandler.AppendMessages(messages, fileName);
                return messages;
            }
            catch (Exception e)
            {
                AnalogyLogMessage empty = new AnalogyLogMessage($"Error occurred processing file {fileName}. Reason: {e.Message}",
                    AnalogyLogLevel.Critical, AnalogyLogClass.General, "Analogy", "None")
                {
                    Source = "Analogy",
                    Module = System.Diagnostics.Process.GetCurrentProcess().ProcessName,
                };
                messagesHandler.AppendMessage(empty, Utils.GetFileNameAsDataSource(fileName));
                return new List<IAnalogyLogMessage> { empty, };
            }
        }

        private List<IAnalogyLogMessage> ProcessJsonPerLine(string fileName, CancellationToken token,
            ILogMessageCreatedHandler messagesHandler)
        {
            List<IAnalogyLogMessage> messages = new List<IAnalogyLogMessage>();

            var jsons = File.ReadAllLines(fileName);
            for (var i = 0; i < jsons.Length; i++)
            {
                var json = jsons[i];
                var msgs = ProcessJsonData(json, fileName, messagesHandler, false);
                messages.AddRange(msgs);
                messagesHandler.ReportFileReadProgress(new AnalogyFileReadProgress(AnalogyFileReadProgressType.Percentage, 1, i, jsons.Length));
            }

            return messages;
        }
    }
}