using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using iTextSharp.text;
using iTextSharp.text.pdf;

using kosal.core.export.settings;

namespace kosal.core.export {
    public abstract class reportBase {
        protected string reportFileName { get; set; }
        protected pageSetup pageSetup { get; set; }
        protected reportInformation reportInfo { get; set; }
        public virtual formatting textFormatting { get; set; }

        protected reportBase( string reportFileName )
            : this( reportFileName, new pageSetup() {
                orientation = settings.consts.enums.pageOrientation.portrait,
                pageSize = settings.consts.enums.pageSize.A4,
                margins = new pageMargin() {
                    bottom = .5f,
                    left = .5f,
                    right = .5f,
                    top = .5f,
                    Unit = settings.consts.enums.measurementUnit.INCH
                }
            } ) {

        }

        protected reportBase( string reportFileName, pageSetup pageSetup ) {
            this.reportFileName = reportFileName;
            this.pageSetup = pageSetup;
            this.textFormatting = new formatting() {
                font = new fontFamily() { name = "courier", size = 10 },
                fontStyle = new fontStyle() {
                    bold = false,
                    italic = false,
                    strikethrough = settings.consts.enums.strikethroughStyle.none,
                    underline = settings.consts.enums.underlineStyle.none
                },
                textColor = System.Drawing.Color.Black,
                textStyle = new textStyle() { horizontal = settings.consts.enums.horizontalAlignment.left, vertical = settings.consts.enums.verticalAlignment.bottom }
            };
        }

        public abstract string generateReport( DataSet reportDataSource, string reportTableName );

        public abstract string generateReport( DataTable reportDataSource );

        public abstract string generateReport<T>( List<T> reportDataSource );

    }
}