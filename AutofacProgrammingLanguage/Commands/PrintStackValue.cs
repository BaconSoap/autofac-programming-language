using AutofacProgrammingLanguage.ValueProviders;

namespace AutofacProgrammingLanguage.Commands
{
    public class PrintStackValue: PrintValue<StackValueProvider>
    {
        public PrintStackValue(StackValueProvider provider) : base(provider)
        {
        }
    }

    public class StackValueProvider : IValueProvider
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
