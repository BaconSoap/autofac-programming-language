using System;

namespace AutofacProgrammingLanguage.LiteralProviders
{
    public class NewlineLiteralProvider: ILiteralProvider
    {
        public string Provide()
        {
            return Environment.NewLine;
        }
    }
}
