using System.Collections.Generic;

namespace AutofacProgrammingLanguage
{
    public class ProgramState
    {
        private readonly Stack<string> _stack;

        public ProgramState()
        {
            _stack = new Stack<string>();
        }

        public void PushStack(string value)
        {
            _stack.Push(value);
        }

        public string PeekStack()
        {
            return _stack.Peek();
        }

        public string PopStack()
        {
            return _stack.Pop();
        }
    }
}
