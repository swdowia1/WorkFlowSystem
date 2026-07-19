using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlowSystem.Application.FUN
{
    internal class classFun
    {
        internal static string DateToString()
        {
            return DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
        }
        internal static DateTime DateNowUTC()
        {
            return DateTime.UtcNow;
        }
    }
}
