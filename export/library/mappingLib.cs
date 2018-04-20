using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

using iTextSharp.text;
using iTextSharp.text.pdf;

using kosal.core.common.library;

using kosal.core.export.settings;
using kosal.core.export.settings.consts.enums;

namespace kosal.core.export.library {
    /// <summary>
    /// 
    /// </summary>
    public static class mappingLib {

        public static int mapAlignment( horizontalAlignment alignment ) {
            switch ( alignment ) {
                case horizontalAlignment.center:
                    return Element.ALIGN_CENTER;
                case horizontalAlignment.justified:
                    return Element.ALIGN_JUSTIFIED;
                case horizontalAlignment.left:
                    return Element.ALIGN_LEFT;
                case horizontalAlignment.right:
                    return Element.ALIGN_RIGHT;
                default:
                    throw new NotSupportedException( string.Format( "Alignment '{0}' is not supportted", alignment.ToString() ) );

            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alignment"></param>
        /// <returns></returns>
        public static int mapAlignment( verticalAlignment alignment ) {
            switch ( alignment ) {
                case verticalAlignment.baseline:
                    return Element.ALIGN_BASELINE;
                case verticalAlignment.bottom:
                    return Element.ALIGN_BOTTOM;
                case verticalAlignment.middle:
                    return Element.ALIGN_MIDDLE;
                case verticalAlignment.top:
                    return Element.ALIGN_TOP;
                default:
                    throw new NotSupportedException( string.Format( "Alignment '{0}' is not supportted", alignment.ToString() ) );

            }
        }
    }
}
