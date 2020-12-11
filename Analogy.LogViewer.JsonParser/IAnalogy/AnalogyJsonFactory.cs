
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.LogViewer.JsonParser.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.CommonUtilities.UI;
using Analogy.LogViewer.JsonParser.Managers;

namespace Analogy.LogViewer.JsonParser.IAnalogy
{
    public class JsonFactory : Template.PrimaryFactory
    {
        internal static Guid Id = new Guid("D7146342-AEB2-4BD5-8710-7D1BF06EA5CF");
        public override Guid FactoryId { get; set; } = Id;
        public override string Title { get; set; } = "Json Log Parser";
        public override IEnumerable<IAnalogyChangeLog> ChangeLog { get; set; } = JsonParser.ChangeLog.GetChangeLog();
        public override Image? LargeImage { get; set; } = Resources.jsonfile32x32;
        public override Image? SmallImage { get; set; } = Resources.jsonfile16x16;
        public override IEnumerable<string> Contributors { get; set; } = new List<string> { "Lior Banai" };
        public override string About { get; set; } = "Json Log Parser";
        
    }

    public class AnalogyJsonDataProviderFactory : Template.DataProvidersFactory
    {
        public override Guid FactoryId { get; set; } = JsonFactory.Id;
        public override string Title { get; set; } = "Json Data Provider";
        public override IEnumerable<IAnalogyDataProvider> DataProviders { get; set; } = new List<IAnalogyDataProvider>()
        {
            new JsonDataProvider(UserSettingsManager.UserSettings.LogParserSettings)
        };
    }

    public class AnalogyJsonCustomActionFactory : IAnalogyCustomActionsFactory
    {
        public Guid FactoryId { get; set; } = JsonFactory.Id;
        public string Title { get; set; } = "Json tools";
        public IEnumerable<IAnalogyCustomAction> Actions { get; } = new List<IAnalogyCustomAction>(0);

    }

    public class AnalogyJsonSettings : Template.UserSettingsFactory
    {

        public override string Title { get; set; } = "Json Parser Settings";

        public override UserControl DataProviderSettings { get; set; } =
            new CommonLogSettingsUC(UserSettingsManager.UserSettings.LogParserSettings);
        public override Guid FactoryId { get; set; } = JsonFactory.Id;
        public override Guid Id { get; set; } = new Guid("5CA8768D-9814-45DB-9350-42E5EE52729E");
        public override Image? SmallImage { get; set; } = Resources.jsonfile16x16;
        public override Image? LargeImage { get; set; } = Resources.jsonfile32x32;

        public override Task SaveSettingsAsync()
        {
            UserSettingsManager.UserSettings.Save();
            return Task.CompletedTask;
        }

    }
}
