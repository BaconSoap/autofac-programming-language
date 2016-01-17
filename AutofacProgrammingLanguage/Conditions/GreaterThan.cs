using AutofacProgrammingLanguage.Commands;
using AutofacProgrammingLanguage.ValueProviders;

namespace AutofacProgrammingLanguage.Conditions
{
    public class GreaterThan<TLeftValueProvider, TRightValueProvider> : ICondition
        where TLeftValueProvider : IValueProvider
        where TRightValueProvider : IValueProvider
    {
        private readonly TLeftValueProvider _left;
        private readonly TRightValueProvider _right;

        public GreaterThan(TLeftValueProvider left, TRightValueProvider right)
        {
            _left = left;
            _right = right;
        }

        public bool Evaluate()
        {
            return _left.ProvideDecimal() > _right.ProvideDecimal();
        }
    }

    public class GreaterThan<TLeft> : GreaterThan<TLeft, StackValueProvider> where TLeft : IValueProvider
    {
        public GreaterThan(TLeft left, StackValueProvider stack) : base(left, stack)
        {
        }
    }
}
