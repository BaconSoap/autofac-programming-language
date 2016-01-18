using AutofacProgrammingLanguage;
using AutofacProgrammingLanguage.Commands;
using AutofacProgrammingLanguage.ValueProviders;

namespace TestConsoleApp
{
    public class HelloWorldProgram: IProgramBody
    {
        public HelloWorldProgram(
            [WithValue("Hello")]PrintValue a,
            [WithValue(" world!")]PrintValueNewLine b)
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