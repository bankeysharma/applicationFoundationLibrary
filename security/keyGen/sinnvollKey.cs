using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using kosal.core.common.library;
using kosal.core.common.binary;

namespace kosal.core.security.keyGen {
    public static class sinnvollKey {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string getNewKey(DateTime timeStamp, DateTime validityTimestamp) {
            var key = new entity.systemLockKey() { id = Guid.NewGuid(), timeStamp = timeStamp, validityTimestamp = validityTimestamp };

            return encryption.Encrypt(serialisation.serialiseToBase64String<entity.systemLockKey>(key));

        }
    }
}
