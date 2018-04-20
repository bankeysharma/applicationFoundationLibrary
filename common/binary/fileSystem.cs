using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kosal.core.common.binary {
    public static class fileSystem {

        public static byte[] readBytes(string fileName) {
            byte[] dataBytes = null;

            using(System.IO.FileStream instFS = new System.IO.FileStream(fileName, System.IO.FileMode.Open)) {
                dataBytes = new byte[instFS.Length];
                
                instFS.Read(dataBytes, 0, dataBytes.Length);

                instFS.Close();                

            }

            return dataBytes;
        }
    }
}
