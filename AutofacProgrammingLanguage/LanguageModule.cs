using System.Linq;
using System.Reflection;
using Autofac;
using AutofacProgrammingLanguage.Commands;
using AutofacProgrammingLanguage.ValueProviders;
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
            var assemblies = new[] { typeof(LanguageModule).Assembly, _executingAssembly };

            builder.RegisterType<ProgramState>().AsSelf().SingleInstance();

            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => t.GetInterfaces().Contains(typeof(IProgramBody)))
                .AsSelf()
                .InstancePerDependency();

            // values

            var genericValueProviderTypes = assemblies.SelectMany(a => a.GetTypes()
                    .Where(t => t.IsGenericType && t.GetInterfaces().Contains(typeof(IValueProvider))));
            var nonGenericValueProviderTypes = assemblies.SelectMany(a => a.GetTypes()
                    .Where(t => !t.IsGenericType && t.GetInterfaces().Contains(typeof(IValueProvider))));

            // generic value providers
            foreach (var genericValueProviderType in genericValueProviderTypes)
            {
                builder
                    .RegisterGeneric(genericValueProviderType)
                    .As(genericValueProviderType)
                    .InstancePerDependency();
            }

            // non-generic value providers
            foreach (var nonGenericValueProviderType in nonGenericValueProviderTypes)
            {
                builder
                    .RegisterType(nonGenericValueProviderType)
                    .AsSelf()
                    .InstancePerDependency();
            }

            var genericCommandTypes = assemblies.SelectMany(a => a.GetTypes()
                    .Where(t => t.IsGenericType && typeof (BaseCommand).IsAssignableFrom(t)));
            var nonGenericCommandTypes = assemblies.SelectMany(a => a.GetTypes()
                    .Where(t => !t.IsGenericType && typeof(BaseCommand).IsAssignableFrom(t)));

            // generic commands
            foreach (var genericCommandType in genericCommandTypes)
            {
                builder
                    .RegisterGeneric(genericCommandType)
                    .As(genericCommandType)
                    .InstancePerDependency()
                    .OnActivated(activated => ((BaseCommand) activated.Instance).Execute());
            }

            // non-generic commands
            foreach (var nonGenericCommandType in nonGenericCommandTypes)
            {
                builder
                    .RegisterType(nonGenericCommandType)
                    .AsSelf()
                    .InstancePerDependency()
                    .OnActivated(activated => ((BaseCommand) activated.Instance).Execute());
            }

            var genericConditionTypes = assemblies.SelectMany(a => a.GetTypes()
                .Where(t => t.IsGenericType && t.GetInterfaces().Contains(typeof(ICondition))));
            var nonGenericConditionTypes = assemblies.SelectMany(a => a.GetTypes()
                .Where(t => !t.IsGenericType && t.GetInterfaces().Contains(typeof(ICondition))));

            foreach (var genericConditionType in genericConditionTypes)
            {
                builder
                    .RegisterGeneric(genericConditionType)
                    .As(genericConditionType)
                    .InstancePerDependency();
            }

            foreach (var nonGenericConditionType in nonGenericConditionTypes)
            {
                builder
                    .RegisterType(nonGenericConditionType)
                    .As(nonGenericConditionType)
                    .InstancePerDependency();
            }
        }
    }
}