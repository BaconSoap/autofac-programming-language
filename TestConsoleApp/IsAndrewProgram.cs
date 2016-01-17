using AutofacProgrammingLanguage;
using AutofacProgrammingLanguage.Commands;
using AutofacProgrammingLanguage.Conditions;
using AutofacProgrammingLanguage.ValueProviders;

namespace TestConsoleApp
{
    public class IsAndrewProgram: IProgramBody
    {
        public IsAndrewProgram(
            PrintValueNewLine<NameQuestionProvider> a,
            ReadLine c,
            PushValue<AndrewProvider> d,
            If<StackEquals, PrintValueNewLine<SuccessValue>, PrintValueNewLine<FailureValue>> e)
        {

        }

        public class NameQuestionProvider : IValueProvider
        {
            public string Provide()
            {
                return "What's your name?";
            }
        }

        public class AndrewProvider : IValueProvider
        {
            public string Provide()
            {
                return "Andrew";
            }
        }

        public class FailureValue : IValueProvider
        {
            public string Provide()
            {
                return "You are not Andrew :( !";
            }
        }

        public class SuccessValue : IValueProvider
        {
            public string Provide()
            {
                return "You are Andrew!";
            }
        }
    }
}
