using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kosal.core.common.library {
    public static class unitConverter {
        public static long inchToPoints( float inchValue ) {
            long pointsInInch = 72;

            return (long) ( inchValue * (float) pointsInInch );

        }
    }
}
