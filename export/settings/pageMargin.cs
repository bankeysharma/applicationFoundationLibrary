using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using kosal.core.export.settings.consts.enums;

namespace kosal.core.export.settings {
    public struct pageMargin {
        public float top { get; set; }
        public float left { get; set; }
        public float bottom { get; set; }
        public float right { get; set; }
        public measurementUnit Unit { get; set; }
    }
}