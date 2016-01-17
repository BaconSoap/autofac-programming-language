using System;

namespace AutofacProgrammingLanguage.ValueProviders
{
    public class NewlineValueProvider: IValueProvider
    {
        public string Provide()
        {
            return Environment.NewLine;
        }
    }
}
