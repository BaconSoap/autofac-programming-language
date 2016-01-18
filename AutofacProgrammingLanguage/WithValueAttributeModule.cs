using System;
using System.Linq;
using Autofac;
using Autofac.Core;
using AutofacProgrammingLanguage.Commands;

namespace AutofacProgrammingLanguage
{
    public class WithValueAttributeModule : Module
    {
        protected override void AttachToComponentRegistration(IComponentRegistry registry, IComponentRegistration registration)
        {
            registration.Preparing += OnComponentPreparing;
        }

        private void OnComponentPreparing(object sender, PreparingEventArgs e)
        {
            e.Parameters = e.Parameters.Union(new Parameter[] {
            new ResolvedParameter(
                (p, i) => p.ParameterType == typeof (PrintValue) || p.ParameterType == typeof(PrintValueNewLine),
                (p, i) =>
                {
                    var attr = (WithValueAttribute) p.GetCustomAttributes(typeof(WithValueAttribute), true).FirstOrDefault();
                    if (attr == null)
                    {
                        throw new InvalidOperationException("usage of ValueProvider requires a WithAttribute param");
                    }
                    BaseCommand value = null;
                    if (p.ParameterType == typeof(PrintValue)) value = new PrintValue(attr.Value);
                    if (p.ParameterType == typeof(PrintValueNewLine)) value = new PrintValueNewLine(attr.Value);
                    value?.Execute();
                    return value;
                })
            });
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class WithValueAttribute : Attribute
    {
        public string Value { get; set; }

        public WithValueAttribute(string value)
        {
            Value = value;
        }
    }
}
