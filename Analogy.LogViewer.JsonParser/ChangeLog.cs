using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using System;
using System.Collections.Generic;

namespace Analogy.LogViewer.JsonParser
{
    public static class ChangeLog
    {
        public static IEnumerable<AnalogyChangeLog> GetChangeLog()
        {
            yield return new AnalogyChangeLog("support multiple date time formats. #217", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2023, 25, 10), "5.0.3.1");
            yield return new AnalogyChangeLog("Initial version", AnalogChangeLogType.None, "Lior Banai", new DateTime(2019, 12, 23), "");
        }
    }
}