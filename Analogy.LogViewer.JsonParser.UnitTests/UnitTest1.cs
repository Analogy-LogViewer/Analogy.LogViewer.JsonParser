using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
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
            JsonSettings js = new JsonSettings();
            js.Format = FileFormat.JsonFormatFile;
            JsonFileLoader fp = new JsonFileLoader(js);
            CancellationTokenSource ts = new CancellationTokenSource();
            MessageHandlerForTesting handler = new MessageHandlerForTesting();
            var msgs = await fp.Process("test.json", ts.Token, handler);
            Assert.IsTrue(msgs.Count() == 4);
        }
        [TestMethod]
        public async Task TestMethod2()
        {
            JsonSettings js = new JsonSettings();
            js.Format = FileFormat.JsonFormatFile;
            JsonFileLoader fp = new JsonFileLoader(js);
            CancellationTokenSource ts = new CancellationTokenSource();
            MessageHandlerForTesting handler = new MessageHandlerForTesting();
            var msgs = await fp.Process("test2.json", ts.Token, handler);
            Assert.IsTrue(msgs.Count() == 1);
        }
        [TestMethod]
        public async Task TestMethod3()
        {
            JsonSettings js = new JsonSettings();
            js.Format = FileFormat.JsonFormatPerLine;
            JsonFileLoader fp = new JsonFileLoader(js);
            CancellationTokenSource ts = new CancellationTokenSource();
            MessageHandlerForTesting handler = new MessageHandlerForTesting();
            var msgs = await fp.Process("icap_log_2020-06-04T16-16-29_2.json", ts.Token, handler);
            Assert.IsTrue(msgs.Count() == 2);
        }
    }
}