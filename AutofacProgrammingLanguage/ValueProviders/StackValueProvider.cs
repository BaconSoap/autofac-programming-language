﻿namespace AutofacProgrammingLanguage.ValueProviders
{
    public class StackValueProvider : IValueProvider
    {
        private readonly ProgramState _state;

        public StackValueProvider(ProgramState state)
        {
            _state = state;
        }

        public string Provide()
        {
            return _state.PeekStack();
        }
    }
}