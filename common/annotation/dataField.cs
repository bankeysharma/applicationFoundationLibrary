using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kosal.core.common.annotation {
    [System.AttributeUsage( AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false )]
    public class dataField: Attribute {
        public string dbField { get; set; }
        public string sourceType { get; set; }
        public string sourceDataFormatter { get; set; }
        public string targetDataFormatter { get; set; }
    }
}
