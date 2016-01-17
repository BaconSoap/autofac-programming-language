using AutofacProgrammingLanguage.Commands;
using AutofacProgrammingLanguage.ValueProviders;

namespace TestConsoleApp
{
    public class AgeProgram
    {
        public AgeProgram(
            PrintValue<QuestionProvider> a,
            PrintValue<NewlineValueProvider> f,
            ReadLine b,
            PrintValue<ResponseBeginProvider> c,
            PrintStackValue d,
            PrintValue<ResponseEndProvider> e)
        {
            
        }

    }

    public class ResponseEndProvider : IValueProvider
    {
        public string Provide()
        {
            return " years old!";
        }
    }

    public class ResponseBeginProvider : IValueProvider
    {
        public string Provide()
        {
            return "You are ";
        }
    }

    public class QuestionProvider : IValueProvider
    {
        public string Provide()
        {
            return "What's your age?";
        }
    }
}