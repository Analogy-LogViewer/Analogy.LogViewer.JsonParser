using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.DataProviders.Extensions;
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.LogViewer.JsonParser.Properties;
using Analogy.LogViewer.NLogProvider;

namespace Analogy.LogViewer.JsonParser.IAnalogy
{
    public class AnalogyJsonFactory : IAnalogyFactory
    {
        public Guid FactoryID { get; } = new Guid("D7146342-AEB2-4BD5-8710-7D1BF06EA5CF");
        public string Title { get; } = "Analogy Json Text Parser";
        public IAnalogyDataProvidersFactory DataProviders { get; }
        public IAnalogyCustomActionsFactory Actions { get; }
        public IEnumerable<IAnalogyChangeLog> ChangeLog => JsonParser.ChangeLog.GetChangeLog();
        public IEnumerable<string> Contributors { get; } = new List<string> { "Lior Banai" };
        public string About { get; } = "Analogy Json Text Parser";

        public AnalogyJsonFactory()
        {
            DataProviders = new AnalogyJsonDataProviderFactory();
            Actions = new AnalogyJsonCustomActionFactory();

        }


    }

    public class AnalogyJsonDataProviderFactory : IAnalogyDataProvidersFactory
    {
        public string Title { get; } = "Analogy XML Data Provider";
        public IEnumerable<IAnalogyDataProvider> Items { get; }

        public AnalogyJsonDataProviderFactory()
        {
            var builtInItems = new List<IAnalogyDataProvider>()
            {
                new JsonDataProvider(UserSettingsManager.UserSettings.LogParserSettings)
            };
            Items = builtInItems;
        }
    }

    public class AnalogyJsonCustomActionFactory : IAnalogyCustomActionsFactory
    {
        public string Title { get; } = "Analogy XML Text tools";
        public IEnumerable<IAnalogyCustomAction> Items { get; }

        public AnalogyJsonCustomActionFactory()
        {
            Items = new List<IAnalogyCustomAction>(0);
        }
    }

    public class AnalogyJsonSettings : IAnalogyDataProviderSettings
    {

        public Guid ID { get; } = new Guid("05E9E0DD-3F3E-4DD8-BFE3-94070212F0F7");

        public string Title { get; } = "Plain Text Settings";
        public UserControl DataProviderSettings { get; } = new JsonParserSettings();
        public Image Icon { get; } = Resources.jsonfile32x32;

        public Task SaveSettingsAsync()
        {
            UserSettingsManager.UserSettings.Save();
            return Task.CompletedTask;
        }

    }
}
