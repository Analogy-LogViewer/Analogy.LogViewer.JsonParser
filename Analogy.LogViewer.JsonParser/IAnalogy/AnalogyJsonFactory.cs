using Analogy.DataProviders.Extensions;
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.LogViewer.JsonParser.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.LogViewer.JsonParser.Managers;

namespace Analogy.LogViewer.JsonParser.IAnalogy
{
    public class JsonFactory : IAnalogyFactory
    {
        internal static Guid Id = new Guid("D7146342-AEB2-4BD5-8710-7D1BF06EA5CF");
        public Guid FactoryId { get; } = Id;
        public string Title { get; } = "Analogy Json Text Parser";
        public IEnumerable<IAnalogyChangeLog> ChangeLog => JsonParser.ChangeLog.GetChangeLog();
        public IEnumerable<string> Contributors { get; } = new List<string> { "Lior Banai" };
        public string About { get; } = "Analogy Json Text Parser";

    }

    public class AnalogyJsonDataProviderFactory : IAnalogyDataProvidersFactory
    {
        public Guid FactoryId { get; } = JsonFactory.Id;
        public string Title { get; } = "Analogy XML Data Provider";
        public IEnumerable<IAnalogyDataProvider> DataProviders { get; } = new List<IAnalogyDataProvider>()
        {
            new JsonDataProvider(UserSettingsManager.UserSettings.LogParserSettings)
        };
    }

    public class AnalogyJsonCustomActionFactory : IAnalogyCustomActionsFactory
    {
        public Guid FactoryId { get; } = JsonFactory.Id;
        public string Title { get; } = "Analogy XML Text tools";
        public IEnumerable<IAnalogyCustomAction> Actions { get; } = new List<IAnalogyCustomAction>(0);

    }

    public class AnalogyJsonSettings : IAnalogyDataProviderSettings
    {

        public string Title { get; } = "Plain Text Settings";
        public UserControl DataProviderSettings { get; } = new JsonParserSettings();
        public Guid FactoryId { get; set; } = JsonFactory.Id;
        public Guid ID { get; set; } = new Guid("5CA8768D-9814-45DB-9350-42E5EE52729E");
        public Image SmallImage { get; }
        public Image LargeImage { get; } = Resources.jsonfile32x32;

        public Task SaveSettingsAsync()
        {
            UserSettingsManager.UserSettings.Save();
            return Task.CompletedTask;
        }

    }
}
