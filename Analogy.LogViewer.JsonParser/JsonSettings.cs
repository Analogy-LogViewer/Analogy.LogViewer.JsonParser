using Analogy.Interfaces;
using System.Collections.Generic;

namespace Analogy.LogViewer.JsonParser
{
    public class JsonSettings
    {
        public FileFormat Format { get; set; }
        public FileFormatDetection FileFormatDetection { get; set; }
        public Dictionary<string, AnalogyLogMessagePropertyName> Fields { get; set; }
        public JsonSettings()
        {
            Fields = new Dictionary<string, AnalogyLogMessagePropertyName>();
            foreach (var property in AnalogyLogMessage.LogMessagePropertyNames)
            {
                Fields.Add(property.Key, property.Value);
            }

            Format = FileFormat.Unknown;
            FileFormatDetection = FileFormatDetection.Automatic;
        }
    }
}
