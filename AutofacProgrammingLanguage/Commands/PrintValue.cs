using System;
using AutofacProgrammingLanguage.ValueProviders;

namespace AutofacProgrammingLanguage.Commands
{
    public class PrintValue<TValueProvider> : BaseCommand where TValueProvider : IValueProvider
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

    public class PrintValue : BaseCommand
    {
        private readonly string _value;

        public PrintValue(string value)
        {
            _value = value;
        }

        public override void Execute()
        {
            Console.Write(_value);
        }
    }

    public class PrintValueNewLine<TValueProvider>: PrintValue<ConcatValueProvider<TValueProvider, NewlineValueProvider>>
        where TValueProvider : IValueProvider
    {
        public PrintValueNewLine(ConcatValueProvider<TValueProvider, NewlineValueProvider> provider) : base(provider)
        {
        }
    }

    public class PrintValueNewLine : BaseCommand
    {
        private readonly string _value;

        public PrintValueNewLine(string value)
        {
            _value = value;
        }

        public override void Execute()
        {
            Console.WriteLine(_value);
        }
    }
}
