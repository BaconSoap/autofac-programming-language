using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutofacProgrammingLanguage.LiteralProviders;

namespace AutofacProgrammingLanguage.Commands
{
    public class PushLiteral<T>: BaseCommand where T: ILiteralProvider
    {
        private readonly T _provider;
        private readonly ProgramState _state;

        public PushLiteral(T provider, ProgramState state)
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
