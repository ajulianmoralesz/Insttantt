using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Application.Extensions
{
    public static class StringExtension
    {
        public static string GetDescription<T>(this T e) where T : IConvertible
        {
            List<string> description = new();

            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = Enum.GetValues(type);

                foreach (Enum val in values)
                {
                    //if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    if ((e as Enum).HasFlag(val)) //this is needed for some flag enums we have
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var descriptionAttributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                        if (descriptionAttributes.Length > 0)
                            description.Add(((DescriptionAttribute)descriptionAttributes[0]).Description);
                        else
                            description.Add(val.ToString());
                    }
                }
            }

            return string.Join(", ", description);
        }

        public static string GetDescriptionByVal<T>(this T e) where T : IConvertible
        {
            string description = "";

            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = Enum.GetValues(type);

                foreach (Enum val in values)
                {
                    if ((e as Enum).Equals(val))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var descriptionAttributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                        if (descriptionAttributes.Length > 0)
                        {
                            description = ((DescriptionAttribute)descriptionAttributes[0]).Description;
                        }
                        else
                        {
                            description = val.ToString();
                        }
                    }
                }
            }

            return description;
        }
    }
}
