using AutofacProgrammingLanguage.LiteralProviders;

namespace AutofacProgrammingLanguage.Commands
{
    public class PrintStackValue: PrintLiteral<StackValueProvider>
    {
        public PrintStackValue(StackValueProvider provider) : base(provider)
        {
        }
    }

    public class StackValueProvider : ILiteralProvider
    {
        private readonly ProgramState _state;

        public StackValueProvider(ProgramState state)
        {
            _state = state;
        }

        public string Provide()
        {
            return _state.PeekStack();
        }
    }
}
