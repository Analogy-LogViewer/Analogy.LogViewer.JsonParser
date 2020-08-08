using Analogy.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Analogy.LogViewer.JsonParser
{
    public class JsonFileLoader
    {
        private ILogParserSettings _logFileSettings;
        public JsonFileLoader(ILogParserSettings logFileSettings)
        {
            _logFileSettings = logFileSettings;
        }

        public async Task<IEnumerable<AnalogyLogMessage>> Process(string fileName, CancellationToken token,
            ILogMessageCreatedHandler messagesHandler)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                AnalogyLogMessage empty = new AnalogyLogMessage($"File is null or empty. Aborting.",
                    AnalogyLogLevel.Critical, AnalogyLogClass.General, "Analogy", "None")
                {
                    Source = "Analogy",
                    Module = System.Diagnostics.Process.GetCurrentProcess().ProcessName
                };
                messagesHandler.AppendMessage(empty, Utils.GetFileNameAsDataSource(fileName));
                return new List<AnalogyLogMessage> { empty };
            }

            if (!_logFileSettings.IsConfigured)
            {
                AnalogyLogMessage empty = new AnalogyLogMessage(
                    $"File Parser is not configured. Please set it first in the settings Window",
                    AnalogyLogLevel.Critical, AnalogyLogClass.General, "Analogy", "None")
                {
                    Source = "Analogy",
                    Module = System.Diagnostics.Process.GetCurrentProcess().ProcessName
                };
                messagesHandler.AppendMessage(empty, Utils.GetFileNameAsDataSource(fileName));
                return new List<AnalogyLogMessage> { empty };
            }

            if (!_logFileSettings.CanOpenFile(fileName))
            {
                AnalogyLogMessage empty = new AnalogyLogMessage(
                    $"File {fileName} Is not supported or not configured correctly in the windows settings",
                    AnalogyLogLevel.Critical, AnalogyLogClass.General, "Analogy", "None")
                {
                    Source = "Analogy",
                    Module = System.Diagnostics.Process.GetCurrentProcess().ProcessName
                };
                messagesHandler.AppendMessage(empty, Utils.GetFileNameAsDataSource(fileName));
                return new List<AnalogyLogMessage> { empty };
            }

            List<AnalogyLogMessage> messages = new List<AnalogyLogMessage>();
            try
            {
                string json = File.ReadAllText(fileName);
                var items = JsonConvert.DeserializeObject<dynamic>(json);
                if (items is JArray jArray)
                {
                    foreach (var item in jArray)
                    {
                        var itemProperties = item.Children<JProperty>().ToList();
                        List<(string, string)> tuples = new List<(string, string)>(itemProperties.Count);
                        foreach (var jprop in itemProperties)
                        {
                            var key = _logFileSettings.GetAnalogyPropertyName(jprop.Name);
                            tuples.Add(key.HasValue
                                ? (key.Value.ToString(), jprop.Value.ToString())
                                : (jprop.Name, jprop.Value.ToString()));

                        }

                        var m = AnalogyLogMessage.Parse(tuples);
                        messages.Add(m);
                    }

                }
                else if (items is JObject jObject)
                {
                    var itemProperties = jObject.Children<JProperty>().ToList();
                    List<(string, string)> tuples = new List<(string, string)>(itemProperties.Count);
                    foreach (var jprop in itemProperties)
                    {
                        var key = _logFileSettings.GetAnalogyPropertyName(jprop.Name);
                        tuples.Add(key.HasValue
                            ? (key.Value.ToString(), jprop.Value.ToString())
                            : (jprop.Name, jprop.Value.ToString()));

                    }

                    var m = AnalogyLogMessage.Parse(tuples);
                    messages.Add(m);
                }
                messagesHandler.AppendMessages(messages, fileName);
                return messages;
            }
            catch (Exception e)
            {
                AnalogyLogMessage empty = new AnalogyLogMessage($"Error occured processing file {fileName}. Reason: {e.Message}",
                    AnalogyLogLevel.Critical, AnalogyLogClass.General, "Analogy", "None")
                {
                    Source = "Analogy",
                    Module = System.Diagnostics.Process.GetCurrentProcess().ProcessName
                };
                messagesHandler.AppendMessage(empty, Utils.GetFileNameAsDataSource(fileName));
                return new List<AnalogyLogMessage> { empty
    };
            }
        }
    }
}
