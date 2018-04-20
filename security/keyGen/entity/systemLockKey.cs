using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kosal.core.security.keyGen.entity {
    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public class systemLockKey {
        /// <summary>
        /// 
        /// </summary>
        public Guid id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime validityTimestamp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime timeStamp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) {
            systemLockKey anotherItem = obj as systemLockKey;

            return this.timeStamp == anotherItem.timeStamp
                        && this.validityTimestamp == anotherItem.validityTimestamp
                        && this.id == anotherItem.id;

        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
}
