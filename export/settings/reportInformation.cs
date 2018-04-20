using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kosal.core.export.settings {
    public struct reportInformation {
        public string authorName { get; set; }
        public DateTime creationDate { get; set; }
        public string creatorName { get; set; }
        public string headerNameAndContent { get; set; }
        public string keywords { get; set; }
        public string langugae { get; set; }
        public string producer { get; set; }
        public string subject { get; set; }
        public string title { get; set; }
    }
}
