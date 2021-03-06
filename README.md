# Befunge Interpreter

This implementation of a Befunge Interpreter was inspired by the following codewars kata:
https://www.codewars.com/kata/befunge-interpreter/csharp

Full details on Befunge can be found at the following Wiki page:
https://en.wikipedia.org/wiki/Befunge

Examples of calling the Befunge Interpreter (output is written to the console):

<code>BefungeInterpreter.Interpret(">987v>.v\nv456< :\n>321 ^ \_@");</code>

<code>BefungeInterpreter.Interpret(">& : 2v2: <\n ` /\n ! 2 \n@,\"t\" \_ :2%!|\n >\"f\",@");</code>

**Befunge-93 instruction list**

| Instruction | Description |
| :--- | :--- |
| <code>0-9</code> | Push this number on the stack |
| <code>+</code> | Addition: Pop *a* and *b*, then push *a*+*b* |
| <code>-</code> | Subtraction: Pop *a* and *b*, then push *b*-*a* |
| <code>\*</code> | Multiplication: Pop *a* and *b*, then push *a*\**b* |
| <code>/</code> | Integer division: Pop *a* and *b*, then push *b*/*a*, rounded towards 0. If *a* is zero, push zero. |
| <code>%</code> | Modulo: Pop *a* and *b*, then push the remainder of the integer division of *b*/*a*. If *a* is zero, push zero. |
| <code>!</code> | Logical NOT: Pop a value. If the value is zero, push 1; otherwise, push zero. |
| <code>`</code> | Greater than: Pop *a* and *b*, then push 1 if *b*&gt;*a*, otherwise zero. |
| <code>&gt;</code> | Start moving right |
| <code>&lt;</code> | Start moving left |
| <code>^</code> | Start moving up |
| <code>v</code> | Start moving down |
| <code>?</code> | Start moving in a random cardinal direction |
| <code>\_</code>| Pop *a* value; move right if value=0, left otherwise |
| <code>\|</code> | Pop *a* value; move down if value=0, up otherwise |
| <code>"</code> | Start string mode: push each character's ASCII value all the way up to the next <code>"</code> |
| <code>:</code> | Duplicate value on top of the stack. If there is nothing on top of the stack, push a *0*. |
| <code>\\</code> | Swap two values on top of the stack. If there is only one value, pretend there is an extra *0* on bottom of the stack. |
| <code>\$</code> | Pop value from the stack and discard it |
| <code>.</code> | Pop value and output as an integer followed by a space |
| <code>,</code> | Pop value and output as ASCII character |
| <code>#</code> | Bridge: Skip next cell |
| <code>p</code> | A "put" call (a way to store a value for later use). Pop *y*, *x*, and *v*, then change the character at (*x*,*y*) in the program to the character with ASCII value *v* |
| <code>g</code> | A "get" call (a way to retrieve data in storage). Pop *y* and *x*, then push ASCII value of the character at that position in the program |
| <code>&</code> | Ask user for a number and push it |
| <code>~</code> | Ask user for a character and push its ASCII value |
| <code>@</code> | End program |
| <code> </code>(space) | No-op. Does nothing |
