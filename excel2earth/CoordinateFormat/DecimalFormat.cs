using System;
using System.Globalization;

namespace excel2earth
{
    public static class DecimalFormat
    {
        // 00.#### style formatting
        public static string Format(double value, int maxDecPlaces)
        {
#if __IOS__ || __WATCHOS__
            // Xamarin does not handle mixed language/region correctly so
            // don't rely on CultureInfo being correct. See
            // https://docs.microsoft.com/en-us/xamarin/ios/app-fundamentals/localization/
            var formatter = new Foundation.NSNumberFormatter();
            formatter.Locale = Foundation.NSLocale.CurrentLocale;
            formatter.MinimumFractionDigits = 0;
            formatter.MaximumFractionDigits = maxDecPlaces;
            formatter.MinimumIntegerDigits = 2;
            return formatter.StringFromNumber(value);
#else
            string format = "00." + new String('#', maxDecPlaces);
            return value.ToString(format, CultureInfo.CurrentUICulture);
#endif

        }
    }
}
