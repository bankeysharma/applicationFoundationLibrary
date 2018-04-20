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

using kosal.core.export.extention;

namespace kosal.core.export.pdf {
    public abstract class pdfExtention: reportBase {

        private Document reportDoc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportFileName"></param>
        public pdfExtention( string reportFileName )
            : base( reportFileName ) {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportFileName"></param>
        /// <param name="pageSetup"></param>
        public pdfExtention( string reportFileName, pageSetup pageSetup ):base(reportFileName, pageSetup) {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportDataSource"></param>
        /// <returns></returns>
        public override string generateReport<T>( List<T> reportDataSource ) {
            using ( FileStream instFS = new FileStream( this.reportFileName, FileMode.Create, FileAccess.Write ) ) {
                try {
                    reportDoc = new Document( this.pageSetup.pageSizeRectangle
                                                , unitConverter.inchToPoints( this.pageSetup.margins.left )
                                                , unitConverter.inchToPoints( this.pageSetup.margins.right )
                                                , unitConverter.inchToPoints( this.pageSetup.margins.top )
                                                , unitConverter.inchToPoints( this.pageSetup.margins.bottom ) );

                    PdfWriter writer = PdfWriter.GetInstance( reportDoc, instFS );

                    reportDoc.Open();

                    writeContent( reportDoc );

                    writer.Flush();

                } finally {
                    if ( this.reportDoc != null ) {
                        this.reportDoc.Close();
                    }
                }
            }

            return this.reportFileName;
        }

        public abstract void writeContent( Document reportDoc );

        #region Pdf Helper Functions 

        /// <summary>
        /// 
        /// </summary>
        protected virtual void addNewPage() {
            if ( this.reportDoc == null )
                return;

            this.reportDoc.NewPage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        protected virtual Paragraph addParagraph( string content ) {
            return this.addParagraph( content, this.textFormatting );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="format"></param>
        protected virtual Paragraph addParagraph( string content, formatting format ) {
            if ( this.reportDoc == null )
                return null;

            var textChunk = new Chunk( content ).applyFont(format).applyTextFormatting(format);
            var para = new Paragraph( textChunk ).applyTextFormatting(format);
            
            this.reportDoc.Add( para );
            
            return para;
        }
        #endregion
    }
}