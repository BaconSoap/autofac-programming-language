using AutofacProgrammingLanguage.Commands;
using AutofacProgrammingLanguage.ValueProviders;

namespace AutofacProgrammingLanguage.Conditions
{
    public class Equals<TLeftValueProvider, TRightValueProvider> : ICondition
        where TLeftValueProvider : IValueProvider
        where TRightValueProvider : IValueProvider
    {
        private readonly TLeftValueProvider _left;
        private readonly TRightValueProvider _right;

        public Equals(TLeftValueProvider left, TRightValueProvider right)
        {
            _left = left;
            _right = right;
        }

        public bool Evaluate()
        {
            return _left.Provide() == _right.Provide();
        }
    }

    public class Equals<TLeft> : Equals<TLeft, StackValueProvider> where TLeft : IValueProvider
    {
        public Equals(TLeft left, StackValueProvider stack) : base(left, stack)
        {
        }
    }
}