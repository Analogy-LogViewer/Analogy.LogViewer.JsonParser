using Newtonsoft.Json;
using System;
using System.IO;

namespace Analogy.LogViewer.JsonParser.Managers
{
    public class UserSettingsManager
    {
        private static readonly Lazy<UserSettingsManager> _instance =
                new Lazy<UserSettingsManager>(() => new UserSettingsManager());
        public static UserSettingsManager UserSettings { get; set; } = _instance.Value;
        private string JsonFileSetting { get; } = "AnalogyJsonParserSettings.json";
        public JsonSettings Settings { get; set; }


        public UserSettingsManager()
        {
            if (File.Exists(JsonFileSetting))
            {
                try
                {
                    string data = File.ReadAllText(JsonFileSetting);
                    Settings = JsonConvert.DeserializeObject<JsonSettings>(data,
                        new JsonSerializerSettings() { ObjectCreationHandling = ObjectCreationHandling.Replace })!;
                }
                catch (Exception ex)
                {
                    Settings = new JsonSettings();
                }
            }
            else
            {
                Settings = new JsonSettings();


            }

        }

        public void Save()
        {
            try
            {
                File.WriteAllText(JsonFileSetting, JsonConvert.SerializeObject(Settings));
            }
            catch (Exception e)
            {
                LogManager.Instance.LogException("Error saving Json parser settings", e, "Json parser");
            }
        }
    }
}
