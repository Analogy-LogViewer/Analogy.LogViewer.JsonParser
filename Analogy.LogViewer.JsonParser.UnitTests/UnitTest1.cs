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
    }
}
