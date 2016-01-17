namespace AutofacProgrammingLanguage.Commands
{
    public class PopValue: BaseCommand
    {
        private readonly ProgramState _state;

        public PopValue(ProgramState state)
        {
            _state = state;
        }

        public override void Execute()
        {
            _state.PopStack();
        }
    }
}
