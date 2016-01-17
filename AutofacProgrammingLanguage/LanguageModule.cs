using System.Linq;
using System.Reflection;
using Autofac;
using AutofacProgrammingLanguage.Commands;
using AutofacProgrammingLanguage.LiteralProviders;
using Module = Autofac.Module;

namespace AutofacProgrammingLanguage
{
    public class LanguageModule : Module
    {
        private readonly Assembly _executingAssembly;

        public LanguageModule(Assembly executingAssembly)
        {
            _executingAssembly = executingAssembly;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProgramState>().AsSelf().SingleInstance();

            builder.RegisterAssemblyTypes(_executingAssembly, typeof(LanguageModule).Assembly)
                .Where(t => t.GetInterfaces().Contains(typeof(ILiteralProvider)))
                .AsSelf()
                .InstancePerDependency();

            builder
                .RegisterGeneric(typeof(PrintLiteral<>))
                .As(typeof(PrintLiteral<>)).InstancePerDependency()
                .OnActivated(activated => (activated.Instance as BaseCommand).Execute());
        }
    }
}
