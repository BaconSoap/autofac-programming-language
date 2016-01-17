using AutofacProgrammingLanguage.Conditions;
using AutofacProgrammingLanguage.ValueProviders;

namespace AutofacProgrammingLanguage.Commands
{
    public class PrintStackValue: PrintValue<StackValueProvider>
    {
        public PrintStackValue(StackValueProvider provider) : base(provider)
        {
        }
    }
}
