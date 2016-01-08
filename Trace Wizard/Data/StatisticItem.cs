using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraceWizard.Data
{
    [Serializable]
    public class StatisticItem
    {
        public static uint NextID;

        public uint InternalID = NextID++;

        public string Category;
        public string Label;
        public string Value;
        public object Tag;
    }
}
