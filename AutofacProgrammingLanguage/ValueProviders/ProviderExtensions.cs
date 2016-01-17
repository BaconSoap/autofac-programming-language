using System;

namespace AutofacProgrammingLanguage.ValueProviders
{
    public static class ProviderExtensions
    {
        public static decimal ProvideDecimal(this IValueProvider provider)
        {
            decimal val;
            if (!decimal.TryParse(provider.Provide(), out val))
            {
                throw new FormatException("not a number");
            }

            return val;
        }
    }
}
