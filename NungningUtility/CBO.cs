using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace NungningUtility
{
    public class CBO
    {
        [DebuggerNonUserCode]
        public CBO()
        {
        }

        private static T CreateObject<T>(IDataReader dr)
        {
            T instance = Activator.CreateInstance<T>();
            if ((object)instance is IHydratable)
            {
                IHydratable hydratable = (object)instance as IHydratable;
                if (hydratable != null)
                    hydratable.Fill(dr);
            }
            else
                CBO.HydrateObject((object)instance, dr);
            return instance;
        }

        private static object CreateObject(Type objType, IDataReader dr)
        {
            object objectValue = RuntimeHelpers.GetObjectValue(Activator.CreateInstance(objType));
            if (objectValue is IHydratable)
            {
                IHydratable hydratable = objectValue as IHydratable;
                if (hydratable != null)
                    hydratable.Fill(dr);
            }
            else
                CBO.HydrateObject(RuntimeHelpers.GetObjectValue(objectValue), dr);
            return objectValue;
        }

        public static ArrayList GetPropertyInfo(Type objType)
        {
            // ArrayList arrayList1;
            ArrayList arrayList2;

            arrayList2 = new ArrayList();
            PropertyInfo[] properties = objType.GetProperties();
            int index = 0;
            while (index < properties.Length)
            {
                PropertyInfo propertyInfo = properties[index];
                arrayList2.Add((object)propertyInfo);
                checked { ++index; }
            }

            return arrayList2;
        }

        private static int[] GetOrdinals(ArrayList objProperties, IDataReader dr)
        {
            int[] numArray = new int[checked(objProperties.Count + 1)];
            Hashtable hashtable = new Hashtable();
            if (dr != null)
            {
                int num1 = 0;
                int num2 = checked(dr.FieldCount - 1);
                int i = num1;
                while (i <= num2)
                {
                    hashtable[(object)dr.GetName(i).ToUpperInvariant()] = (object)"";
                    checked { ++i; }
                }
                int num3 = 0;
                int num4 = checked(objProperties.Count - 1);
                int index = num3;
                while (index <= num4)
                {
                    string upperInvariant = ((MemberInfo)objProperties[index]).Name.ToUpperInvariant();
                    numArray[index] = !hashtable.ContainsKey((object)upperInvariant) ? -1 : dr.GetOrdinal(upperInvariant);
                    checked { ++index; }
                }
            }
            return numArray;
        }

        private static void HydrateObject(object objObject, IDataReader dr)
        {
            ArrayList propertyInfo = CBO.GetPropertyInfo(objObject.GetType());
            int[] ordinals = CBO.GetOrdinals(propertyInfo, dr);
            int num1 = 0;
            int num2 = checked(propertyInfo.Count - 1);
            int index = num1;
            while (index <= num2)
            {
                PropertyInfo objPropertyInfo = (PropertyInfo)propertyInfo[index];
                Type propertyType = objPropertyInfo.PropertyType;
                if (objPropertyInfo.CanWrite && ordinals[index] != -1)
                {
                    object objectValue = RuntimeHelpers.GetObjectValue(dr.GetValue(ordinals[index]));
                    Type type = objectValue.GetType();
                    if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(objectValue)))
                        objPropertyInfo.SetValue(RuntimeHelpers.GetObjectValue(objObject), RuntimeHelpers.GetObjectValue(Null.SetNull(objPropertyInfo)), (object[])null);
                    else if (propertyType.Equals(type))
                    {
                        objPropertyInfo.SetValue(RuntimeHelpers.GetObjectValue(objObject), RuntimeHelpers.GetObjectValue(objectValue), (object[])null);
                    }
                    else
                    {
                        try
                        {
                            if (propertyType.BaseType.Equals(typeof(Enum)))
                            {
                                if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(objectValue)))
                                    objPropertyInfo.SetValue(RuntimeHelpers.GetObjectValue(objObject), RuntimeHelpers.GetObjectValue(Enum.ToObject(propertyType, Convert.ToInt32(RuntimeHelpers.GetObjectValue(objectValue)))), (object[])null);
                                else
                                    objPropertyInfo.SetValue(RuntimeHelpers.GetObjectValue(objObject), RuntimeHelpers.GetObjectValue(Enum.ToObject(propertyType, RuntimeHelpers.GetObjectValue(objectValue))), (object[])null);
                            }
                            else if (propertyType.FullName.Equals("System.Guid"))
                                objPropertyInfo.SetValue(RuntimeHelpers.GetObjectValue(objObject), RuntimeHelpers.GetObjectValue(Convert.ChangeType((object)new Guid(objectValue.ToString()), propertyType)), (object[])null);
                            else
                                objPropertyInfo.SetValue(RuntimeHelpers.GetObjectValue(objObject), RuntimeHelpers.GetObjectValue(objectValue), (object[])null);
                        }
                        catch (Exception ex)
                        {
                            ProjectData.SetProjectError(ex);
                            objPropertyInfo.SetValue(RuntimeHelpers.GetObjectValue(objObject), RuntimeHelpers.GetObjectValue(Convert.ChangeType(RuntimeHelpers.GetObjectValue(objectValue), propertyType)), (object[])null);
                            ProjectData.ClearProjectError();
                        }
                    }
                }
                checked { ++index; }
            }
        }

        public static List<T> FillCollection<T>(IDataReader dr)
        {
            List<T> objList = new List<T>();
            while (dr.Read())
            {
                T obj = CBO.CreateObject<T>(dr);
                objList.Add(obj);
            }
            if (dr != null)
                dr.Close();
            return objList;
        }

        public static object FillObject(IDataReader dr, Type objType)
        {
            return CBO.FillObject(dr, objType, true);
        }

        public static object FillObject(IDataReader dr, Type objType, bool ManageDataReader)
        {
            bool flag;
            if (ManageDataReader)
            {
                flag = false;
                if (dr.Read())
                    flag = true;
            }
            else
                flag = true;
            object obj = !flag ? (object)null : RuntimeHelpers.GetObjectValue(CBO.CreateObject(objType, dr));
            if (ManageDataReader && dr != null)
                dr.Close();
            return obj;
        }

        public static T FillObject<T>(IDataReader dr)
        {
            return CBO.FillObject<T>(dr, true);
        }

        public static T FillObject<T>(IDataReader dr, bool ManageDataReader)
        {
            bool flag;
            if (ManageDataReader)
            {
                flag = false;
                if (dr.Read())
                    flag = true;
            }
            else
                flag = true;
            T obj = !flag ? default(T) : CBO.CreateObject<T>(dr);
            if (ManageDataReader && dr != null)
                dr.Close();
            return obj;
        }
    }
}
