using AutofacProgrammingLanguage.Commands;
using AutofacProgrammingLanguage.ValueProviders;

namespace AutofacProgrammingLanguage.Conditions
{
    public class NotEquals<TLeftValueProvider, TRightValueProvider> : ICondition
        where TLeftValueProvider : IValueProvider
        where TRightValueProvider : IValueProvider
    {
        private readonly TLeftValueProvider _left;
        private readonly TRightValueProvider _right;

        public NotEquals(TLeftValueProvider left, TRightValueProvider right)
        {
            _left = left;
            _right = right;
        }

        public bool Evaluate()
        {
            return _left.Provide() != _right.Provide();
        }
    }

    public class NotEquals<TLeft> : NotEquals<TLeft, StackValueProvider> where TLeft : IValueProvider
    {
        public NotEquals(TLeft left, StackValueProvider stack) : base(left, stack)
        {
        }
    }
}