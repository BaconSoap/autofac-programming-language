using System;
using AutofacProgrammingLanguage.ValueProviders;

namespace AutofacProgrammingLanguage.Commands
{
    public class PrintValue<TValueProvider>: BaseCommand where TValueProvider: IValueProvider
    {
        private readonly TValueProvider _provider;

        public PrintValue(TValueProvider provider)
        {
            _provider = provider;
        }

        public override void Execute()
        {
            Console.Write(_provider.Provide());
        }
    }
}
