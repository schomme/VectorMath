using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3DVectorMath
{
    public static class Constants
    {
        public static readonly Regex NumberValidationRegex = new Regex(@"^-?\d*\.?\d*?$");
    }
}
