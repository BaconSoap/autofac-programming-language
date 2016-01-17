using System;
using System.Diagnostics;
using AutofacProgrammingLanguage;
using AutofacProgrammingLanguage.Commands;
using AutofacProgrammingLanguage.Conditions;
using AutofacProgrammingLanguage.ValueProviders;

namespace TestConsoleApp
{
    public class OverUnderProgram : IProgramBody
    {
        public OverUnderProgram(
            PushValue<RandomValueProvider> dummyData,
            While<NotEquals<StaticRandomNumberValueProvider>, GameLoop> loop,
            PrintValueNewLine<YouWin> winnerIsYou
            )
        {
        }

        public class GameLoop : IProgramBody
        {
            public GameLoop(
                PopValue cleanupPreviousRun,
                PrintValueNewLine<GuessANumber> a,
                ReadLine c,
                If<GreaterThan<StaticRandomNumberValueProvider>, PrintValueNewLine<TooLow>,
                    If<LessThan<StaticRandomNumberValueProvider>, PrintValueNewLine<TooHigh>, NoOp>> d
                )
            {
            }
        }

        public class YouWin : IValueProvider
        {
            public string Provide()
            {
                return "You win!!!!";
            }
        }

        public class TooLow : IValueProvider
        {
            public string Provide()
            {
                return "You guessed too low. Try again!";
            }
        }

        public class TooHigh : IValueProvider
        {
            public string Provide()
            {
                return "You guessed too high. Try again!";
            }
        }

        public class GuessANumber : IValueProvider
        {
            public string Provide()
            {
                return "Guess a number!";
            }
        }

        public class StaticRandomNumberValueProvider : IValueProvider
        {
            private static int? _number;

            public string Provide()
            {
                Trace.WriteLine(_number);
                return (_number ?? (_number = new Random().Next(100))).ToString();
            }
        }
    }
}