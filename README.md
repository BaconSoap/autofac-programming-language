# Autofac Programming Language (AFPL)

The Autofac programming language is a new .NET based language (really an interpreter) that uses only Autofac constructor injection. Every command, literal, expression, etc is a type defined by constructor parameters. Program execution is defined by the order that the constructor values are resolved in. Inversion of control has never been so accessible!

## Values

Values are the core data types in AFPL. A value is always retrieved from an `IValueProvider`. To create a new value (including a new literal), simply create a new class that implements `IValueProvider` and implement `string Provide()`. This is modular and good separation of concerns - hardcoded literals inhibit testing, and now you can inject anything you want where previously you'd have to say `Console.WriteLine("Hello World!")`.

Built-in values:

- `NewLineValueProvider`: provides a newline (specifically `Environment.NewLine`)

## Commands

Commands tell the runtime what to do. You execute commands by placing them in order in the constructor of a type that is then resolved. If your program (the constructor signature) gets too long, you can easily break it apart by creating new types to inject.

Built-in commands:

- `PrintValue<TValueProvider>`: prints the value returned from `TValueProvider`
- `PushStack<TValueProvider>`: pushes the value returned from `TValueProvider` onto the program stack
- `PopStack`: pops the top value from the program stack
- `PrintStackValue`: prints the top value from the program stack without popping it
- `ReadLine`: reads a line from console input and places it onto the program stack
- `If<TConditional, TSuccess, TElse>`: if the conditional provided by `TConditonal` evaluates to `true`, then it resolves (executes) `TSuccess` - otherwise it resolves (executes) `TElse`

## Conditionals

Conditionals implement `ICondition`. They have one must-implement method: `bool Evaluate()`. A conditional is `true` if `Evaluate()` returns `true`.

AFPL has the following built-in conditionals:

- `Equals<TLeftValueProvider, TRightValueProvider>`: `true` if the value provided by `TLeftValueProvider` equals the value provided by `TRightValueProvider`
- `Equals<TLeftValueProvider>`: `true` if the value provided by `TLeftValueProvider` is equal to the top value of the program stack
- `StackEquals`: `true` if the top value of the program stack is equal to the second-to-top value of the program stack

## Examples

See [IsAndrewProgram.cs](TestConsoleApp/IsAndrewProgram.cs) for an example of a program.

## But why?

Why not?