using System.Collections.Generic;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;

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
            CancellationTokenSource ts = new CancellationTokenSource();
            MessageHandlerForTesting handler = new MessageHandlerForTesting();
            await fp.Process("test2.clef", ts.Token, handler);
        }

        [TestMethod]
        public async Task TestMethod2()
        {
            ILogParserSettings lp = new LogParserSettings();
            lp.IsConfigured = true;
            lp.SupportedFilesExtensions=new List<string>(){"*.json"};
            lp.Maps=new Dictionary<int, AnalogyLogMessagePropertyName>();
            JsonFileLoader fp = new JsonFileLoader(lp);
            CancellationTokenSource ts = new CancellationTokenSource();
            MessageHandlerForTesting handler = new MessageHandlerForTesting();
            await fp.Process("icap_log_2020-06-04T16-16-29_2.json", ts.Token, handler);
        }
    }
}
