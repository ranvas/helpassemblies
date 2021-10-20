using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzt.MTDATA.Utils
{
    public static class DecimalHelper
    {
        public static decimal ToDecimal(this string source, decimal? defValue = null)
        {
            decimal result = 0;
            if (decimal.TryParse(source?.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out result))
                return result;

            if (defValue.HasValue)
                return defValue.Value;

            throw new ArgumentOutOfRangeException("source", "source=" + source);
        }
    }
}
