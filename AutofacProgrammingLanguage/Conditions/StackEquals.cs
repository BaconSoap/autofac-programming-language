using AutofacProgrammingLanguage.Commands;
using AutofacProgrammingLanguage.LiteralProviders;

namespace AutofacProgrammingLanguage.Conditions
{
    public class StackEquals : Equals<StackValueProvider, StackEquals.SecondStackValueProvider>
    {
        public StackEquals(StackValueProvider left, SecondStackValueProvider right) : base(left, right)
        {
        }

        public class SecondStackValueProvider : ILiteralProvider
        {
            private readonly ProgramState _state;

            public SecondStackValueProvider(ProgramState state)
            {
                _state = state;
            }

            public string Provide()
            {
                var tmp = _state.PopStack();
                var result = _state.PeekStack();
                _state.PushStack(tmp);
                return result;
            }
        }
    }
}