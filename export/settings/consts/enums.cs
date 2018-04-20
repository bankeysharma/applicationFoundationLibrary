using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kosal.core.export.settings.consts.enums {
    /// <summary>
    /// 
    /// </summary>
    public enum pageSize: byte {
        _11X17 = 0,
        A0,
        A1,
        A10,
        A2,
        A3,
        A4,
        A4_LANDSCAPE,
        A5,
        A6,
        A7,
        A8,
        A9,
        ARCH_A,
        ARCH_B,
        ARCH_C,
        ARCH_D,
        ARCH_E,
        B0,
        B1,
        B10,
        B2,
        B3,
        B4,
        B5,
        B6,
        B7,
        B8,
        B9,
        CROWN_OCTAVO,
        CROWN_QUARTO,
        DEMY_OCTAVO,
        DEMY_QUARTO,
        EXECUTIVE,
        FLSA,
        FLSE,
        HALFLETTER,
        ID_1,
        ID_2,
        ID_3,
        LARGE_CROWN_OCTAVO,
        LARGE_CROWN_QUARTO,
        LEDGER,
        LEGAL,
        LEGAL_LANDSCAPE,
        LETTER,
        LETTER_LANDSCAPE,
        NOTE,
        PENGUIN_LARGE_PAPERBACK,
        PENGUIN_SMALL_PAPERBACK,
        POSTCARD,
        ROYAL_OCTAVO,
        ROYAL_QUARTO,
        SMALL_PAPERBACK,
        TABLOID
    }

    /// <summary>
    /// 
    /// </summary>
    public enum pageOrientation: byte { 
        landscape = 0,
        portrait
    }

    /// <summary>
    /// 
    /// </summary>
    public enum measurementUnit: byte { 
        INCH
    }

    /// <summary>
    /// 
    /// </summary>
    public enum underlineStyle: byte {
        none,
        singleLine,
        doubleLine
    }

    /// <summary>
    /// 
    /// </summary>
    public enum strikethroughStyle: byte { 
        none,
        singleLine,
        doubleLine
    }

    public enum verticalAlignment: byte {
        baseline,
        bottom,
        middle,
        top
    }

    public enum horizontalAlignment: byte {
        left,
        right,
        center,
        justified
    }
}