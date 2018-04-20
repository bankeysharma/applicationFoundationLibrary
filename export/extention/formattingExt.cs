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

using kosal.core.export.library;
using kosal.core.export.settings;
using kosal.core.export.settings.consts.enums;

namespace kosal.core.export.extention {
    public static class formattingExt {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public static Paragraph applyTextFormatting( this Paragraph para, formatting format ) {
            para.Alignment = mappingLib.mapAlignment( format.textStyle.horizontal );
            return para;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public static Chunk applyTextFormatting( this Chunk textChunk, formatting format ) {
            switch (format.fontStyle.underline) {
                case underlineStyle.singleLine:
                case underlineStyle.doubleLine:
                    textChunk.SetUnderline( 5, 10 );
                    break;
            }
            return textChunk;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public static Paragraph applyFont( this Paragraph para, formatting format ) {
            Font appliedFont = FontFactory.GetFont( format.font.name, format.font.size, new BaseColor( format.textColor ) );
            para.Font = appliedFont;
            return para;
        }

        public static Chunk applyFont( this Chunk textChunk, formatting format ) {
            Font appliedFont = FontFactory.GetFont( format.font.name, format.font.size, new BaseColor( format.textColor ) );
            textChunk.Font = appliedFont;
            return textChunk;
        }
    }
}
