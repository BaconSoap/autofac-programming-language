using System;

namespace AutofacProgrammingLanguage.Commands
{
    public class If<TCondition, TSuccess, TElse>: BaseCommand where TCondition: ICondition
    {
        private readonly TCondition _condition;
        private readonly Lazy<TSuccess> _success;
        private readonly Lazy<TElse> _else;

        public If(TCondition condition, Lazy<TSuccess> success, Lazy<TElse> @else)
        {
            _condition = condition;
            _success = success;
            _else = @else;
        }

        public override void Execute()
        {
            if (_condition.Evaluate())
            {
                var _ = _success.Value;
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
