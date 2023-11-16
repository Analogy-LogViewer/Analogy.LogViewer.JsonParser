﻿using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.LogViewer.JsonParser.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;

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
            new JsonDataProvider(),
        };
    }

    public class AnalogyJsonCustomActionFactory : IAnalogyCustomActionsFactory
    {
        public Guid FactoryId { get; set; } = JsonFactory.Id;
        public string Title { get; set; } = "Json tools";
        public IEnumerable<IAnalogyCustomAction> Actions { get; } = new List<IAnalogyCustomAction>(0);
    }
}