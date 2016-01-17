using System;

namespace AutofacProgrammingLanguage.Commands
{
    public class ReadLine: BaseCommand
    {
        private readonly ProgramState _state;

        public ReadLine(ProgramState state)
        {
            _state = state;
        }

        public override void Execute()
        {
            _state.PushStack(Console.ReadLine());
        }
    }
}
