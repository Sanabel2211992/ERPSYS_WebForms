using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace ERPSYS.Helpers
{
    public static class HelperFunctions
    {
        public static string SerializeObject<T>(T source)
        {
            var serializer = new XmlSerializer(typeof(T));

            using(var sw = new System.IO.StringWriter())
            using(var writer = new XmlTextWriter(sw))
            {
                serializer.Serialize(writer, source);
                return sw.ToString();
            }
        }

        public static T DeSerializeObject<T>(string xml)
        {
            using(System.IO.StringReader sr = new System.IO.StringReader(xml))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(sr);
            }
        }

        public static object ReturnZeroIfNull(object value)
        {
            if (value == System.DBNull.Value)
                return 0;
            else
                return value;
        }

        public static object ReturnEmptyIfNull(object value)
        {
            if(value == System.DBNull.Value)
                return string.Empty;
            else
                return value;
        }

        public static object ReturnFalseIfNull(object value)
        {
            if(value == System.DBNull.Value)
                return false;
            else
                return value;
        }

        public static object ReturnDateTimeMinIfNull(object value)
        {
            if(value == System.DBNull.Value)
                return DateTime.MinValue;
            else
                return value;
        }

        public static DataSet MappingDataSet(DataSet xmlDataSet)
        {
            foreach(DataColumn column in xmlDataSet.Tables[0].Columns)
            {
                column.ColumnMapping = MappingType.Attribute;
            }

            return xmlDataSet;
        }

        public static DataTable MappingDataTable(DataTable dt)
        {
            foreach(DataColumn column in dt.Columns)
            {
                column.ColumnMapping = MappingType.Attribute;
            }

            return dt;
        }

        public static bool CompareList<T>(this List<T> list1, List<T> list2)
        {
            //if any of the list is null, return false
            if ((list1 == null && list2 != null) || (list2 == null && list1 != null))
                return false;

            //if both lists are null, return true, since its same
            else if (list1 == null)
                return true;

            //if count don't match between 2 lists, then return false
            if (list1.Count != list2.Count)
                return false;

            bool isEqual = true;
            foreach (T item in list1)
            {
                T object1 = item;
                T object2 = list2.ElementAt(list1.IndexOf(item));
                Type type = typeof(T);

                //if any of the object inside list is null and other list has some value for the same object  then return false
                if ((object1 == null && object2 != null) || (object2 == null && object1 != null))
                {
                    isEqual = false;
                    break;
                }

                foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                {
                    if (property.Name != "ExtensionData")
                    {
                        string object1Value = string.Empty;
                        string object2Value = string.Empty;
                        if (type.GetProperty(property.Name).GetValue(object1, null) != null)

                            object1Value = type.GetProperty(property.Name).GetValue(object1, null).ToString();
                        if (type.GetProperty(property.Name).GetValue(object2, null) != null)
                            object2Value = type.GetProperty(property.Name).GetValue(object2, null).ToString();
                        //if any of the property value inside an object in the list didnt match, return false
                        if (object1Value.Trim() != object2Value.Trim())
                        {
                            isEqual = false;
                            break;
                        }
                    }

                }

            }
            //if all the properties are same then return true
            return isEqual;
        }

    }
}