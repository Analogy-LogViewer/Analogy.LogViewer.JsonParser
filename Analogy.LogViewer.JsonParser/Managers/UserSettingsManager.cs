using System;
using System.Collections.Generic;
using System.IO;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Newtonsoft.Json;

namespace Analogy.LogViewer.JsonParser.Managers
{
    public class UserSettingsManager
    {
        private static readonly Lazy<UserSettingsManager> _instance =
                new Lazy<UserSettingsManager>(() => new UserSettingsManager());
        public static UserSettingsManager UserSettings { get; set; } = _instance.Value;
        private string JsonFileSetting { get; } = "AnalogyJsonParserSettings.AnalogySettings";
        public ILogParserSettings LogParserSettings { get; set; }


        public UserSettingsManager()
        {
            if (File.Exists(JsonFileSetting))
            {
                try
                {
                    string data = File.ReadAllText(JsonFileSetting);
                    LogParserSettings = JsonConvert.DeserializeObject<LogParserSettings>(data);
                }
                catch (Exception ex)
                {
                    LogParserSettings = new LogParserSettings();
                    LogParserSettings.SupportedFilesExtensions = new List<string> { "*.json" };
                }
            }
            else
            {
                LogParserSettings = new LogParserSettings();
                LogParserSettings.SupportedFilesExtensions = new List<string> { "*.json" };

            }

        }

        public void Save()
        {
            try
            {
                File.WriteAllText(JsonFileSetting, JsonConvert.SerializeObject(LogParserSettings));
            }
            catch (Exception e)
            {
               LogManager.Instance.LogException(e,"Json parser","Error saving Json parser settings");
            }
        }
    }
}
