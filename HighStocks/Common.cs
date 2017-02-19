using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace HighStocks
{
    public class Common
    {

        public static List<T> ConvertDataTableToList<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach(DataRow dr in dt.Rows)
            {
                T item = GetItem<T>(dr);
                data.Add(item);
            }

            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();
            foreach(DataColumn column in dr.Table.Columns)
            {
                foreach(PropertyInfo prop in temp.GetProperties())
                {
                    if (prop.Name == column.ColumnName)
                        prop.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }

            return obj;
        }
    }
}