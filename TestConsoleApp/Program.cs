using System;
using Autofac;
using AutofacProgrammingLanguage;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new LanguageModule(typeof (Program).Assembly));
            builder.RegisterType<HelloWorldProgram>().AsSelf().InstancePerDependency();
            builder.RegisterType<AgeProgram>().AsSelf().InstancePerDependency();
            var container = builder.Build();

            // good practice to never resolve from root container!
            var programLifetimeScope = container.BeginLifetimeScope();
            programLifetimeScope.Resolve<HelloWorldProgram>();
            programLifetimeScope.Resolve<AgeProgram>();

            Console.ReadKey();
        }
    }
}
