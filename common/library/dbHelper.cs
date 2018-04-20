using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

using kosal.core.common.annotation;
using System.Reflection;

namespace kosal.core.common.library {
    /// <summary>
    /// 
    /// </summary>
    public static class dbHelper {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataSource"></param>
        /// <returns></returns>
        public static List<T> readDr<T>( IDataReader dataSource ) where T: class, new() {
            List<T> dataList = new List<T>();
            PropertyInfo[] properties = typeof( T ).GetProperties();
            T item = null;

            using ( dataSource ) {
                while ( dataSource.Read() ) {
                    item = new T();
                    foreach ( PropertyInfo property in properties ) {
                        var attribute = Attribute.GetCustomAttribute( property, typeof( dataField ) ) as dataField;

                        if ( attribute != null ) {
                            var value = castValue( dataSource[attribute.dbField ?? property.Name], attribute.sourceType ?? "System.String", property.PropertyType );
                            property.SetValue( item, value, null ); // null means no indexes
                        }
                    }

                    dataList.Add( item );
                }

                dataSource.Close();
                dataSource.Dispose();

            }

            return dataList;

        }

        private static object castValue( object value, string sourceType, Type targetType ) {

            switch ( sourceType ) {
                case "System.DateTime":
                    switch ( targetType.Name ) {
                        case"TimeSpan":
                            var dtValue = (DateTime) value;
                            TimeSpan tsValue = dtValue.TimeOfDay;
                            value = tsValue;
                            break;
                    }
                    break;
            }
            
            return value;
        }
    }
}
