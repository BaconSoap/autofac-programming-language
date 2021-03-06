﻿namespace AutofacProgrammingLanguage.ValueProviders
{
    public class SecondStackValueProvider : IValueProvider
    {
        private readonly ProgramState _state;

        public SecondStackValueProvider(ProgramState state)
        {
            _state = state;
        }

        public string Provide()
        {
            var tmp = _state.PopStack();
            var result = _state.PeekStack();
            _state.PushStack(tmp);
            return result;
        }
    }
}