using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

using kosal.core.export.settings.consts.enums;

namespace kosal.core.export.settings {
    /// <summary>
    /// 
    /// </summary>
    public struct formatting {
        public fontFamily font { get; set; }
        public fontStyle fontStyle { get; set; }
        public textStyle textStyle { get; set; }
        public Color textColor { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public struct fontFamily {
        public string name { get; set; }
        public int size { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public struct fontStyle {
        public bool bold { get; set; }
        public bool italic { get; set; }
        public strikethroughStyle strikethrough { get; set; }
        public underlineStyle underline { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public struct textStyle {
        public verticalAlignment vertical { get; set; }
        public horizontalAlignment horizontal { get; set; }
    }
}