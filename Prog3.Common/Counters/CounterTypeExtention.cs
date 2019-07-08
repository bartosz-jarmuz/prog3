using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog3.Common.Counters
{
    public static class CounterTypeExtention
    {
        public static string GetLabel(this CounterType e)
        {
            Type type = e.GetType();
            Array values = Enum.GetValues(type);

            foreach (int val in values)
            {
                if ((CounterType)val == e)
                {
                    System.Reflection.MemberInfo[] memberInfo = type.GetMember(type.GetEnumName(val));
                    DescriptionAttribute descriptionAttribute = memberInfo[0]
                        .GetCustomAttributes(typeof(DescriptionAttribute), false)
                        .FirstOrDefault() as DescriptionAttribute;

                    if (descriptionAttribute != null)
                    {
                        return descriptionAttribute.Description;
                    }
                }
            }

            return null;
        }
    }
}
