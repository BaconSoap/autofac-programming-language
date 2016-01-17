using AutofacProgrammingLanguage.Conditions;

namespace AutofacProgrammingLanguage.Commands
{
    public class PrintStackValue: PrintValue<StackValueProvider>
    {
        public PrintStackValue(StackValueProvider provider) : base(provider)
        {
        }
    }
}
