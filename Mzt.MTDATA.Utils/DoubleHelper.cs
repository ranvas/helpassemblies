using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzt.MTDATA.Utils
{
    public static class DoubleHelper
    {
        public static double ToDouble(this string source, double? defValue = null)
        {
            double result = 0;
            if (double.TryParse(source?.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out result))
                return result;

            if (defValue.HasValue)
                return defValue.Value;

            throw new ArgumentOutOfRangeException("source", "source=" + source);
        }
    }
}
