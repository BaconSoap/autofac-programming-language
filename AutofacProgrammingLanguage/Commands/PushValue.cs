using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutofacProgrammingLanguage.ValueProviders;

namespace AutofacProgrammingLanguage.Commands
{
    public class PushValue<T>: BaseCommand where T: IValueProvider
    {
        private readonly T _provider;
        private readonly ProgramState _state;

        public PushValue(T provider, ProgramState state)
        {
            _provider = provider;
            _state = state;
        }

        public override void Execute()
        {
            _state.PushStack(_provider.Provide());
        }
    }
}
