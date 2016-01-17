using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutofacProgrammingLanguage.Commands;
using AutofacProgrammingLanguage.Conditions;
using AutofacProgrammingLanguage.ValueProviders;

namespace TestConsoleApp
{
    public class IsAndrewProgram
    {
        public IsAndrewProgram(
            PrintValue<NameQuestionProvider> a,
            PrintValue<NewlineValueProvider> b,
            ReadLine c,
            PushValue<AndrewProvider> d,
            If<StackEquals, PrintValue<SuccessValue>, PrintValue<FailureValue>> e)
        {

        }

        public class NameQuestionProvider : IValueProvider
        {
            public string Provide()
            {
                return "What's your name?";
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

    public class AndrewProvider: IValueProvider
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
