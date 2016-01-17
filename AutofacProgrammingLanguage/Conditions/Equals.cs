using AutofacProgrammingLanguage.Commands;
using AutofacProgrammingLanguage.LiteralProviders;

namespace AutofacProgrammingLanguage.Conditions
{
    public class Equals<TLeft, TRight> : ICondition where TLeft : ILiteralProvider where TRight : ILiteralProvider
    {
        private readonly TLeft _left;
        private readonly TRight _right;

        public Equals(TLeft left, TRight right)
        {
            _left = left;
            _right = right;
        }

        public bool Evaluate()
        {
            return _left.Provide() == _right.Provide();
        }
    }

    public class Equals<TLeft> : Equals<TLeft, StackValueProvider> where TLeft : ILiteralProvider
    {
        public Equals(TLeft left, StackValueProvider stack) : base(left, stack)
        {   
        }
    }
}