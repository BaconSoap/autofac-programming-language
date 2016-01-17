using System;

namespace AutofacProgrammingLanguage.Commands
{
    public class If<TCondition, TTrue, TElse>: BaseCommand where TCondition: ICondition
    {
        private readonly TCondition _condition;
        private readonly Lazy<TTrue> _true;
        private readonly Lazy<TElse> _else;

        public If(TCondition condition, Lazy<TTrue> @true, Lazy<TElse> @else)
        {
            _condition = condition;
            _true = @true;
            _else = @else;
        }

        public override void Execute()
        {
            if (_condition.Evaluate())
            {
                var _ = _true.Value;
            }
            else
            {
                var _ = _else.Value;
            }
        }
    }

    public interface ICondition
    {
        bool Evaluate();
    }
}
