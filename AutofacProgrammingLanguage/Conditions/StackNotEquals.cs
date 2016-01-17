using AutofacProgrammingLanguage.Commands;
using AutofacProgrammingLanguage.ValueProviders;

namespace AutofacProgrammingLanguage.Conditions
{
    public class StackNotEquals : NotEquals<StackValueProvider, SecondStackValueProvider>
    {
        public StackNotEquals(StackValueProvider left, SecondStackValueProvider right) : base(left, right)
        {
        }
    }
}