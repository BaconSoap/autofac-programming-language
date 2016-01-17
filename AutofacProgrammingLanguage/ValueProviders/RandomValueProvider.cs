using System;

namespace AutofacProgrammingLanguage.ValueProviders
{
    public class RandomValueProvider: IValueProvider
    {
        public string Provide()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
