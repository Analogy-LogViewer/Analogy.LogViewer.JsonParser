using System;
using System.Threading;
using System.Threading.Tasks;
using Analogy.DataProviders.Extensions;
using Analogy.Interfaces;
using Analogy.LogViewer.NLogProvider;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Analogy.LogViewer.JsonParser.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            ILogParserSettings lp = new LogParserSettings();
            lp.IsConfigured = true;
            JsonFileLoader fp = new JsonFileLoader(lp);
            CancellationTokenSource ts=new CancellationTokenSource();
            await fp.Process("test2.clef", ts.Token, null);
        }
    }
}
