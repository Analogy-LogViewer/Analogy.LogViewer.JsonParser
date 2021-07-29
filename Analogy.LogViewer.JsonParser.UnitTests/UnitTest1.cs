using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
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
            JsonFileLoader fp = new JsonFileLoader(js);
            CancellationTokenSource ts = new CancellationTokenSource();
            MessageHandlerForTesting handler = new MessageHandlerForTesting();
            await fp.Process("test.json", ts.Token, handler);
        }
        [TestMethod]
        public async Task TestMethod2()
        {
            JsonSettings js = new JsonSettings();
            JsonFileLoader fp = new JsonFileLoader(js);
            CancellationTokenSource ts = new CancellationTokenSource();
            MessageHandlerForTesting handler = new MessageHandlerForTesting();
            await fp.Process("test2.json", ts.Token, handler);
        }
        [TestMethod]
        public async Task TestMethod3()
        {
            JsonSettings js = new JsonSettings();
            JsonFileLoader fp = new JsonFileLoader(js);
            CancellationTokenSource ts = new CancellationTokenSource();
            MessageHandlerForTesting handler = new MessageHandlerForTesting();
            await fp.Process("icap_log_2020-06-04T16-16-29_2.json", ts.Token, handler);
        }
    }
}
