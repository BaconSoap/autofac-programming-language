using AutofacProgrammingLanguage.Commands;
using AutofacProgrammingLanguage.ValueProviders;

namespace AutofacProgrammingLanguage.Conditions
{
    public class StackGreaterThan : GreaterThan<StackValueProvider, SecondStackValueProvider>
    {
        public StackGreaterThan(StackValueProvider left, SecondStackValueProvider right) : base(left, right)
        {
        }
    }
}
