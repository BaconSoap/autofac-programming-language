using AutofacProgrammingLanguage.Commands;
using AutofacProgrammingLanguage.ValueProviders;

namespace AutofacProgrammingLanguage.Conditions
{
    public class StackLessThan : LessThan<StackValueProvider, SecondStackValueProvider>
    {
        public StackLessThan(StackValueProvider left, SecondStackValueProvider right) : base(left, right)
        {
        }
    }
}
