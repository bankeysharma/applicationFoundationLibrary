using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using iTextSharp.text;
using iTextSharp.text.pdf;

using kosal.core.export.settings.consts.enums;

namespace kosal.core.export.settings {
    public class pageSetup {
        private pageSize _pageSize = pageSize.A4;
        private Rectangle _pageSizeRectangle = PageSize.A4;

        /// <summary>
        /// 
        /// </summary>
        public pageSize pageSize { get { return this._pageSize; }
            set {
                if ( this._pageSize == value )
                    return;
                this._pageSize = value;
                this.initialisePageSize();
            } 
        }
        /// <summary>
        /// 
        /// </summary>
        public pageOrientation orientation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public pageMargin margins { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public void initialisePageSize() {
            switch ( this._pageSize ) {
                case pageSize.A4:
                    this._pageSizeRectangle = PageSize.A4;
                    break;
                default:
                    throw new NotSupportedException( string.Format( "Page size '{0}' is not supported", this.pageSize.ToString() ) );
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public Rectangle pageSizeRectangle {
            get {
                return this._pageSizeRectangle;
            }
        }
    }
}