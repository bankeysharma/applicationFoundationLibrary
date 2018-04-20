using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Compression;
using System.IO;

namespace kosal.core.common.binary {
    /// <summary>
    /// 
    /// </summary>
    public static class compression {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] getCompressed(byte[] data) {
           
            //using(MemoryStream instMS = new MemoryStream()) {
            //    DeflateStream dfStream = new DeflateStream(instMS, CompressionMode.Compress);            
            //    dfStream.Write(data, 0, data.Length);
            //    instMS.Seek(0, SeekOrigin.Begin);

            //    return instMS.ToArray();

            //}

            using(MemoryStream compressedStream = new MemoryStream()) {
                using(DeflateStream zipStream = new DeflateStream(compressedStream, CompressionMode.Compress)) {
                    zipStream.Write(data, 0, data.Length);
                    
                    zipStream.Close();
                    //compressedStream.Close();

                    return compressedStream.ToArray();
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] getDecompressed(byte[] data) {
            //int readLength = 0;

            //using(MemoryStream instMSDeflatted = new MemoryStream()) {
            //    using(MemoryStream instMS = new MemoryStream(data)) {
            //        DeflateStream dfStream = new DeflateStream(instMS, CompressionMode.Decompress);
            //        //instMS.Seek(0, SeekOrigin.Begin);

            //        while( true ) {
            //            byte[] patch = new byte[ 1024 ];
            //            readLength = dfStream.Read(patch, 0, patch.Length);                    
            //            if(readLength == 0) break;
            //            instMSDeflatted.Write(patch, 0, readLength);
            //        }

            //        instMSDeflatted.Seek(0, SeekOrigin.Begin);
            //        return instMSDeflatted.ToArray();
            //    }
            //}

            if(data == null || data.Length == 0) return null;

            using(MemoryStream compressedStream = new MemoryStream(data)) {
                using(DeflateStream zipStream = new DeflateStream(compressedStream, CompressionMode.Decompress)) {
                    using(MemoryStream resultStream = new MemoryStream()) {
                        var buffer = new byte[4096];
                        int read;

                        while ((read = zipStream.Read(buffer, 0, buffer.Length)) > 0) {
                            resultStream.Write(buffer, 0, read);
                        }
                        zipStream.Close();

                        return resultStream.ToArray();
                    }
                }
            }

        }

    }
}