using AutofacProgrammingLanguage.Commands;
using AutofacProgrammingLanguage.LiteralProviders;

namespace TestConsoleApp
{
    public class HelloWorldProgram
    {
        public HelloWorldProgram(
            PrintLiteral<HelloLiteralProvider> a,
            PrintLiteral<WorldLiteralProvider> b,
            PrintLiteral<NewlineLiteralProvider> c)
        {
            
        }

        public class HelloLiteralProvider : ILiteralProvider
        {
            public string Provide()
            {
                return "Hello";
            }
        }

        public class WorldLiteralProvider : ILiteralProvider
        {
            public string Provide()
            {
                return " World!";
            }
        }
    }
}