using System;
using System.Drawing;
using Analogy.Interfaces;
using Analogy.LogViewer.JsonParser.Properties;

namespace Analogy.LogViewer.JsonParser.IAnalogy
{
    public class JsonParserComponentImages : IAnalogyComponentImages
    {
        public Image GetLargeImage(Guid analogyComponentId)
        {
            if (analogyComponentId == JsonFactory.Id)
                return Resources.jsonfile32x32;
            return null;
        }

        public Image GetSmallImage(Guid analogyComponentId)
        {
            if (analogyComponentId == JsonFactory.Id)
                return Resources.jsonfile16x16;
            return null;
        }

        public Image GetOnlineConnectedLargeImage(Guid analogyComponentId) => null;

        public Image GetOnlineConnectedSmallImage(Guid analogyComponentId) => null;

        public Image GetOnlineDisconnectedLargeImage(Guid analogyComponentId) => null;

        public Image GetOnlineDisconnectedSmallImage(Guid analogyComponentId) => null;
    }
}
