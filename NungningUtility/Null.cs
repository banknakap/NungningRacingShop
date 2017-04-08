
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace NungningUtility
{
    public class Null
    {
        public static short NullShort
        {
            get
            {
                return -1;
            }
        }

        public static int NullInteger
        {
            get
            {
                return -1;
            }
        }

        public static byte NullByte
        {
            get
            {
                return byte.MaxValue;
            }
        }

        public static float NullSingle
        {
            get
            {
                return float.MinValue;
            }
        }

        public static double NullDouble
        {
            get
            {
                return double.MinValue;
            }
        }

        public static Decimal NullDecimal
        {
            get
            {
                return new Decimal(-1, -1, -1, true, (byte)0);
            }
        }

        public static DateTime NullDate
        {
            get
            {
                return DateTime.MinValue;
            }
        }

        public static string NullString
        {
            get
            {
                return "";
            }
        }

        public static bool NullBoolean
        {
            get
            {
                return false;
            }
        }

        public static Guid NullGuid
        {
            get
            {
                return Guid.Empty;
            }
        }

        [DebuggerNonUserCode]
        public Null()
        {
        }

        public static object SetNull(object objValue, object objField)
        {
            return !Information.IsDBNull(RuntimeHelpers.GetObjectValue(objValue)) ? RuntimeHelpers.GetObjectValue(objValue) : (!(objField is short) ? (!(objField is byte) ? (!(objField is int) ? (!(objField is float) ? (!(objField is double) ? (!(objField is Decimal) ? (!(objField is DateTime) ? (!(objField is string) ? (!(objField is bool) ? (!(objField is Guid) ? (object)null : (object)Null.NullGuid) : (object)Null.NullBoolean) : (object)Null.NullString) : (object)Null.NullDate) : (object)Null.NullDecimal) : (object)Null.NullDouble) : (object)Null.NullSingle) : (object)Null.NullInteger) : (object)Null.NullByte) : (object)Null.NullShort);
        }

        public static object SetNull(PropertyInfo objPropertyInfo)
        {
            string Left = objPropertyInfo.PropertyType.ToString();
            object obj;
            if (Operators.CompareString(Left, "System.Int16", false) == 0)
                obj = (object)Null.NullShort;
            else if (Operators.CompareString(Left, "System.Int32", false) == 0 || Operators.CompareString(Left, "System.Int64", false) == 0)
                obj = (object)Null.NullInteger;
            else if (Operators.CompareString(Left, "system.Byte", false) == 0)
                obj = (object)Null.NullByte;
            else if (Operators.CompareString(Left, "System.Single", false) == 0)
                obj = (object)Null.NullSingle;
            else if (Operators.CompareString(Left, "System.Double", false) == 0)
                obj = (object)Null.NullDouble;
            else if (Operators.CompareString(Left, "System.Decimal", false) == 0)
                obj = (object)Null.NullDecimal;
            else if (Operators.CompareString(Left, "System.DateTime", false) == 0)
                obj = (object)Null.NullDate;
            else if (Operators.CompareString(Left, "System.String", false) == 0 || Operators.CompareString(Left, "System.Char", false) == 0)
                obj = (object)Null.NullString;
            else if (Operators.CompareString(Left, "System.Boolean", false) == 0)
                obj = (object)Null.NullBoolean;
            else if (Operators.CompareString(Left, "System.Guid", false) == 0)
            {
                obj = (object)Null.NullGuid;
            }
            else
            {
                Type propertyType = objPropertyInfo.PropertyType;
                if (propertyType.BaseType.Equals(typeof(Enum)))
                {
                    Array values = Enum.GetValues(propertyType);
                    Array.Sort(values);
                    obj = RuntimeHelpers.GetObjectValue(Enum.ToObject(propertyType, RuntimeHelpers.GetObjectValue(values.GetValue(0))));
                }
                else
                    obj = (object)null;
            }
            return obj;
        }

        public static object GetNull(object objField, object objDBNull)
        {
            object objectValue = RuntimeHelpers.GetObjectValue(objField);
            if (objField == null)
                objectValue = RuntimeHelpers.GetObjectValue(objDBNull);
            else if (objField is byte)
            {
                if ((int)Convert.ToByte(RuntimeHelpers.GetObjectValue(objField)) == (int)Null.NullByte)
                    objectValue = RuntimeHelpers.GetObjectValue(objDBNull);
            }
            else if (objField is short)
            {
                if ((int)Convert.ToInt16(RuntimeHelpers.GetObjectValue(objField)) == (int)Null.NullShort)
                    objectValue = RuntimeHelpers.GetObjectValue(objDBNull);
            }
            else if (objField is int)
            {
                if (Convert.ToInt32(RuntimeHelpers.GetObjectValue(objField)) == Null.NullInteger)
                    objectValue = RuntimeHelpers.GetObjectValue(objDBNull);
            }
            else if (objField is float)
            {
                if ((double)Convert.ToSingle(RuntimeHelpers.GetObjectValue(objField)) == (double)Null.NullSingle)
                    objectValue = RuntimeHelpers.GetObjectValue(objDBNull);
            }
            else if (objField is double)
            {
                if (Convert.ToDouble(RuntimeHelpers.GetObjectValue(objField)) == Null.NullDouble)
                    objectValue = RuntimeHelpers.GetObjectValue(objDBNull);
            }
            else if (objField is Decimal)
            {
                if (Decimal.Compare(Convert.ToDecimal(RuntimeHelpers.GetObjectValue(objField)), Null.NullDecimal) == 0)
                    objectValue = RuntimeHelpers.GetObjectValue(objDBNull);
            }
            else if (objField is DateTime)
            {
                if (DateTime.Compare(Convert.ToDateTime(RuntimeHelpers.GetObjectValue(objField)).Date, Null.NullDate.Date) == 0)
                    objectValue = RuntimeHelpers.GetObjectValue(objDBNull);
            }
            else if (objField is string)
            {
                if (objField == null)
                    objectValue = RuntimeHelpers.GetObjectValue(objDBNull);
                else if (Operators.CompareString(objField.ToString(), Null.NullString, false) == 0)
                    objectValue = RuntimeHelpers.GetObjectValue(objDBNull);
            }
            else if (objField is bool)
            {
                if (Convert.ToBoolean(RuntimeHelpers.GetObjectValue(objField)) == Null.NullBoolean)
                    objectValue = RuntimeHelpers.GetObjectValue(objDBNull);
            }
            else if (objField is Guid)
            {
                object obj = objField;
                Guid guid = NullGuid;
                if ((obj != null ? (Guid)obj : guid).Equals(Null.NullGuid))
                    objectValue = RuntimeHelpers.GetObjectValue(objDBNull);
            }
            return objectValue;
        }

        public static bool IsNull(object objField)
        {
            return objField == null || (!(objField is int) ? (!(objField is short) ? (!(objField is byte) ? (!(objField is float) ? (!(objField is double) ? (!(objField is Decimal) ? (!(objField is DateTime) ? (!(objField is string) ? (!(objField is bool) ? objField is Guid && objField.Equals((object)Null.NullGuid) : objField.Equals((object)Null.NullBoolean)) : objField.Equals((object)Null.NullString)) : Conversions.ToDate(objField).Date.Equals(Null.NullDate.Date)) : objField.Equals((object)Null.NullDecimal)) : objField.Equals((object)Null.NullDouble)) : objField.Equals((object)Null.NullSingle)) : objField.Equals((object)Null.NullByte)) : objField.Equals((object)Null.NullShort)) : objField.Equals((object)Null.NullInteger));
        }
    }
}
