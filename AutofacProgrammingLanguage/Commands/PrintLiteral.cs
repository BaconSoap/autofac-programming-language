using System;
using AutofacProgrammingLanguage.LiteralProviders;

namespace AutofacProgrammingLanguage.Commands
{
    public class PrintLiteral<TLiteralProvider>: BaseCommand where TLiteralProvider: ILiteralProvider
    {
        private readonly TLiteralProvider _provider;

        public PrintLiteral(TLiteralProvider provider)
        {
            _provider = provider;
        }

        public override void Execute()
        {
            Console.Write(_provider.Provide());
        }
    }
}
