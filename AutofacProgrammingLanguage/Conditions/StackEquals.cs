using AutofacProgrammingLanguage.Commands;
using AutofacProgrammingLanguage.ValueProviders;

namespace AutofacProgrammingLanguage.Conditions
{
    public class StackEquals : Equals<StackValueProvider, SecondStackValueProvider>
    {
        public StackEquals(StackValueProvider left, SecondStackValueProvider right) : base(left, right)
        {
        }
    }
}