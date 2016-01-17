using AutofacProgrammingLanguage.Commands;
using AutofacProgrammingLanguage.ValueProviders;

namespace TestConsoleApp
{
    public class HelloWorldProgram
    {
        public HelloWorldProgram(
            PrintValue<HelloValueProvider> a,
            PrintValue<WorldValueProvider> b,
            PrintValue<NewlineValueProvider> c)
        {
            
        }

        public class HelloValueProvider : IValueProvider
        {
            public string Provide()
            {
                return "Hello";
            }
        }

        public class WorldValueProvider : IValueProvider
        {
            public string Provide()
            {
                return " World!";
            }
        }
    }
}