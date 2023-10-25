using Analogy.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Analogy.LogViewer.JsonParser
{
    public class JsonSettings
    {
        public FileFormat Format { get; set; }
        public FileFormatDetection FileFormatDetection { get; set; }
        public Dictionary<AnalogyLogMessagePropertyName, List<string>> Fields { get; set; }
        public List<string> DateFormats { get; set; }
        public DateParseHandling DateParseHandling { get; set; }
        public JsonSettings()
        {
            DateParseHandling = DateParseHandling.None;
            DateFormats = new List<string>();
            Fields = new Dictionary<AnalogyLogMessagePropertyName, List<string>>();
            foreach (var property in AnalogyLogMessage.LogMessagePropertyNames.Values)
            {
                Fields.Add(property, new List<string> { property.ToString() });
            }

            Format = FileFormat.Unknown;
            FileFormatDetection = FileFormatDetection.Automatic;
        }

        public void AddField(AnalogyLogMessagePropertyName analogyProperty, string jsonFieldName)
        {
            if (!Fields[analogyProperty].Contains(jsonFieldName))
            {
                Fields[analogyProperty].Add(jsonFieldName);

            }
        }

        public void DeleteField(AnalogyLogMessagePropertyName analogyProperty, string jsonFieldName)
        {
            Fields[analogyProperty].Remove(jsonFieldName);

        }

        public bool TryGetAnalogyValue(string jpropName, out string prop)
        {
            foreach (KeyValuePair<AnalogyLogMessagePropertyName, List<string>> pair in Fields)
            {
                if (pair.Value.Contains(jpropName))
                {
                    prop = pair.Key.ToString();
                    return true;
                }
            }

            prop = "";
            return false;
        }

        public List<string> GetValues(AnalogyLogMessagePropertyName selectedField)
        {
            return Fields[selectedField];
        }
    }
}
