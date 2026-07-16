using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WorkFlowSystem.Application.DTO;

namespace WorkFlowSystem.Application.Common
{
    public static class EnumHelper
    {
        public static List<LookupDto> ToSelectList<TEnum>(TEnum? selected = null)
            where TEnum : struct, Enum
        {
            return Enum.GetValues<TEnum>()
                .Select(e => new LookupDto
                {
                    Value = Convert.ToInt32(e),
                    Text = GetDescription(e)
                   
                })
                .ToList();
        }

        private static string GetDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            var attribute = field?
                .GetCustomAttribute<DescriptionAttribute>();

            return attribute?.Description ?? value.ToString();
        }
    }
}
