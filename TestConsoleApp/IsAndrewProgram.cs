using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutofacProgrammingLanguage.Commands;
using AutofacProgrammingLanguage.Conditions;
using AutofacProgrammingLanguage.LiteralProviders;

namespace TestConsoleApp
{
    public class IsAndrewProgram
    {
        public IsAndrewProgram(
            PrintLiteral<NameQuestionProvider> a,
            PrintLiteral<NewlineLiteralProvider> b,
            ReadLine c,
            PushLiteral<AndrewProvider> d,
            If<StackEquals, PrintLiteral<SuccessLiteral>, PrintLiteral<FailureLiteral>> e)
        {

        }

        public class NameQuestionProvider : ILiteralProvider
        {
            public string Provide()
            {
                return "What's your name?";
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

    public class AndrewProvider: ILiteralProvider
    {
        public string Provide()
        {
            return "Andrew";
        }
    }

    public class FailureLiteral : ILiteralProvider
    {
        public string Provide()
        {
            return "You are not Andrew :( !";
        }
    }

    public class SuccessLiteral : ILiteralProvider
    {
        public string Provide()
        {
            return "You are Andrew!";
        }
    }
}
