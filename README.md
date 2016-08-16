# Autofac Programming Language (AFPL)

The Autofac programming language is a new .NET based language (really an interpreter) that uses only Autofac constructor injection. Every command, literal, expression, etc is a type defined by constructor parameters. Program execution is defined by the order that the constructor values are resolved in. Inversion of control has never been so accessible!

## Values

Values are the core data types in AFPL. A value is always retrieved from an `IValueProvider`. To create a new value (including a new literal), simply create a new class that implements `IValueProvider` and implement `string Provide()`. This is modular and good separation of concerns - hardcoded literals inhibit testing, and now you can inject anything you want where previously you'd have to say `Console.WriteLine("Hello World!")`.

Built-in values:

- `NewLineValueProvider`: provides a newline (specifically `Environment.NewLine`)
- `ConcatValueProvider<TValueProvider1, TValueProvider2>`: provides the concatenation of `TValueProvider1` and `TValueProvider2`
- `StackValueProvider`: provides the top value from the program stack (without removing it)
- `SecondStackValueProvider`: provides the second-from-the-top value from the program stack (without removing it or the top value)
- `RandomValueProvider`: provides a random GUID

## Commands

Commands tell the runtime what to do. You execute commands by placing them in order in the constructor of a type that is then resolved. If your program (the constructor signature) gets too long, you can easily break it apart by creating new types to inject.

Built-in commands:

- `NoOp`: does nothing
- `PrintValue<TValueProvider>`: prints the value returned from `TValueProvider`
- `PrintValueNewLine<TValueProvider>`: prints the value returned from `TValueProvider` followed by a newline
- `PushValue<TValueProvider>`: pushes the value returned from `TValueProvider` onto the program stack
- `PopValue`: pops the top value from the program stack
- `PrintStackValue`: prints the top value from the program stack without popping it
- `ReadLine`: reads a line from console input and places it onto the program stack
- `If<TCondition, TSuccess, TElse>`: if the conditional provided by `TConditon` evaluates to `true`, then it resolves (executes) `TSuccess` - otherwise it resolves (executes) `TElse`
- `While<TCondition, TBody>`: resolves (executes) `TBody` as long as `TCondition` evaluates to `true`

## Conditionals

Conditionals implement `ICondition`. They have one must-implement method: `bool Evaluate()`. A conditional is `true` if `Evaluate()` returns `true`.

AFPL has the following built-in conditionals:

- `Equals<TLeftValueProvider, TRightValueProvider>`: `true` if the value provided by `TLeftValueProvider` equals the value provided by `TRightValueProvider`
- `Equals<TLeftValueProvider>`: `true` if the value provided by `TLeftValueProvider` is equal to the top value of the program stack
- `StackEquals`: `true` if the top value of the program stack is equal to the second-to-top value of the program stack
- `NotEquals<TLeftValueProvider, TRightValueProvider>`: `true` if the value provided by `TLeftValueProvider` does not equal the value provided by `TRightValueProvider`
- `NotEquals<TLeftValueProvider>`: `true` if the value provided by `TLeftValueProvider` is not equal to the top value of the program stack
- `StackNotEquals`: `true` if the top value of the program stack is not equal to the second-to-top value of the program stack
- `GreaterThan<TLeftValueProvider, TRightValueProvider>`: `true` if the value provided by `TLeftValueProvider` is greater than the value provided by `TRightValueProvider`
- `GreaterThan<TLeftValueProvider>`: `true` if the value provided by `TLeftValueProvider` is greater than to the top value of the program stack
- `StackGreaterThan`: `true` if the top value of the program stack is greater than the second-to-top value of the program stack
- `LessThan<TLeftValueProvider, TRightValueProvider>`: `true` if the value provided by `TLeftValueProvider` is less than the value provided by `TRightValueProvider`
- `LessThan<TLeftValueProvider>`: `true` if the value provided by `TLeftValueProvider` is less than to the top value of the program stack
- `StackLessThan`: `true` if the top value of the program stack is less than the second-to-top value of the program stack

## Examples

See [IsAndrewProgram.cs](TestConsoleApp/IsAndrewProgram.cs) for an example of a program, or [OverUnderProgram](TestConsoleApp/OverUnderProgram.cs) for a full-fledged number guessing game.

## But why?

Why not?

## Accolades, quotes, etc.

- "I need an adult"
- "You were so preoccupied with whether or not you could that you didn't stop to think if you should"
- "Dear god, why?"
- "Whoever write this should be killed on the spot"
