using Autofac;

namespace AutofacProgrammingLanguage.Commands
{
    public class While<TCondition, TBody>: BaseCommand
        where TCondition: ICondition
    {
        private readonly TCondition _condition;
        private readonly ILifetimeScope _scope;

        public While(TCondition condition, ILifetimeScope scope)
        {
            _condition = condition;
            _scope = scope;
        }

        public override void Execute()
        {
            while (_condition.Evaluate())
            {
                _scope.Resolve<TBody>();
            }
        }
    }
}
