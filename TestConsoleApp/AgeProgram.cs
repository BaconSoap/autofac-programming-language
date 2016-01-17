using AutofacProgrammingLanguage.Commands;
using AutofacProgrammingLanguage.LiteralProviders;

namespace TestConsoleApp
{
    public class AgeProgram
    {
        public AgeProgram(
            PrintLiteral<QuestionProvider> a,
            PrintLiteral<NewlineLiteralProvider> f,
            ReadLine b,
            PrintLiteral<ResponseBeginProvider> c,
            PrintStackValue d,
            PrintLiteral<ResponseEndProvider> e)
        {
            
        }

    }

    public class ResponseEndProvider : ILiteralProvider
    {
        public string Provide()
        {
            return " years old!";
        }
    }

    public class ResponseBeginProvider : ILiteralProvider
    {
        public string Provide()
        {
            return "You are ";
        }
    }

    public class QuestionProvider : ILiteralProvider
    {
        public string Provide()
        {
            return "What's your age?";
        }
    }
}