using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Runtime.Serialization.Formatters.Binary;

namespace kosal.core.common.binary {
    public static class serialisation {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static byte[] serialise<T>(T item) {
            BinaryFormatter instBF = new BinaryFormatter();
            byte[] binaryData; 

            using(MemoryStream instMS = new MemoryStream(500)) {
                instBF.Serialize(instMS, item);
                instMS.Seek(0, SeekOrigin.Begin);
            
                binaryData = instMS.ToArray();                
            }

            return binaryData;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string serialiseToBase64String<T>(T item) {
            return Convert.ToBase64String(serialisation.serialise<T>(item));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectBytes"></param>
        /// <returns></returns>
        public static T deserialise<T>(byte[] objectBytes) {
            BinaryFormatter instBF = new BinaryFormatter();

            T item;

            using (MemoryStream instMS = new MemoryStream(objectBytes)) {
                item = (T) instBF.Deserialize(instMS);       
            }

            return item;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T deserialiseFromBase64String<T>(string value) {
            return serialisation.deserialise<T>(Convert.FromBase64String(value));
        }
    }
}
