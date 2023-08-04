using System;
using System.Collections.Generic;
using Analogy.Interfaces;

namespace Analogy.LogViewer.JsonParser
{
    public static class ChangeLog
    {
        public static IEnumerable<AnalogyChangeLog> GetChangeLog()
        {

            yield return new AnalogyChangeLog("Initial version", AnalogChangeLogType.None, "Lior Banai", new DateTime(2019, 12, 23), "");

        }
    }
}
