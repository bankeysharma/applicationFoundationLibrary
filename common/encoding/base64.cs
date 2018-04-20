using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace kosal.core.common.encoding {
    public static class base64 {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataBytes"></param>
        /// <returns></returns>
        public static string getEncoded(byte[] dataBytes) {
            return Convert.ToBase64String(dataBytes);            
        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] getDecoded(string value) {
            return Convert.FromBase64String(value);
        
        }
    }
}
