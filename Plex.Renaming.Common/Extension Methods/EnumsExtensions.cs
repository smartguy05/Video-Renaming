using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Video.Renaming.Common.Extension_Methods
{
    public static class EnumsExtensions
    {
        public static string ToString<T>(this T source) where T : Enum
        {
            var fi = source.GetType().GetField(source.ToString());

            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : source.ToString();
        }

        // public static List<string> ToValueList<T>(this T source) where T : struct, IConvertible
        // {
        //     if (!typeof(T).IsEnum)
        //     {
        //         throw new InvalidEnumArgumentException();
        //     }
        //
        //     var values = Enum.GetValues(typeof(T)) as int[];
        //     var returnValues = new List<string>();
        //
        //     foreach (var value in values)
        //     {
        //         var test = (T)Enum.ToObject(typeof(T), value);
        //         test.tost
        //         returnValues.Add(((T)value));
        //     }
        //
        //     throw new NotImplementedException();
        //     // var val = source.GetType().
        // } 
    }
}