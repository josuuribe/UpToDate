﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace UpToDate
{
    public class Expressions
    {
        // C# 7
        public Expressions() => Console.WriteLine("Expression");

        private string name = "First";

        // C# 7 Auto properties
        public string Name
        {
            get => name;
            set => name = value;
        }

        // C# 6 Property Initializers
        public string Surname { get; set; } = "Surname";

        // C# 6
        public void WriteName() => Console.WriteLine(Name);
        public void WriteSurname() => Console.WriteLine(Surname);

        public void TernaryCondition()
        {
            var a = 10;
            var b = a > 10 ? true : false;

            Console.WriteLine(b);
        }

        public void TernaryRefCondition()
        {// C# 7.2
            var a = 10;
            var b = 3;
            var c = 6;
            ref int res = ref (a > 10) ? ref b : ref c;// It will return c (because it's a reference)

            res = -1; // Now c is -1

            Console.WriteLine(b); // It remains 3
            Console.WriteLine(c); // It is new value -1
        }

        public void NullCoalescing()
        {
            object a = null;
            object b = a ?? new string("Null!"); // Syntax sugar to check nulls, it will has a value 'null'

            Console.WriteLine(b);
        }

        public void NullCoalescingThrow()
        {// C# 7
            try
            {
                object a = null;
                object b = a ?? throw new ArgumentNullException("Object null."); // If null you can also throw an exception
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane.Message);
            }
        }

        public void NullPropagationOperator()
        {// C# 6
            object d = null;
            var a = new { A = new { B = new { C = d } } };

            Console.WriteLine($"{nameof(a.A.B.C)} = {a?.A?.B?.C?.ToString()}"); // Eternal null propagation
        }

        public void Interpolation(decimal value)
        {// C# 6
            System.Console.WriteLine($"You called with => {value:N3}");// Format number to show only 3 decimal places
        }

        public void NameOf(string param)
        {// C# 6
            Console.WriteLine($"Var name {nameof(param)} = {param}");
        }

        public int CastInteger(string numericValue)
        {
            if (int.TryParse(numericValue, out int i))// Not necessary to declare extra var, 'i' in place
                return i;
            return -1;
        }

        public void Discard(string integer)
        {
            bool b = int.TryParse(integer, out int _);
            if (b)
            {
                Console.WriteLine("Can be casted.");
            }
            else
            {
                Console.WriteLine("It can not be casted.");
            }
        }

        public double ReturnDiscard(double value)
        {
            var _ = Math.Sqrt(value++);
            return Math.Ceiling(_);
        }

        public string ConvertUsingIf(object element)
        {// C# 7
            if (element is string s)
                return s.ToUpper();// Casting included in the same line
            else if (element is int i)
                return Math.Abs(i).ToString();
            else if (element is double d)
                return Math.Truncate(d).ToString();
            else
                return string.Empty;
        }

        public string ConvertToStringUsingSwitch(object element)
        {// C# 7
            switch (element)
            {// Switch case based
                case string s:
                    return s.ToUpper();
                case int i:
                    return Math.Abs(i).ToString();
                case double d:
                    return Math.Truncate(d).ToString();
                default:
                    return string.Empty;
            }
        }

        public string ConvertToStringUsingSwitchWhen(object element)
        {// C# 7
            switch (element)
            {
                case string s when s.Length > 0:
                    return s.ToUpper();
                case int i when i > 5: // Not only be integer but also greater than 5
                    return Math.Abs(i).ToString();
                case int i: // Only integer, but any integer despite it value
                    return Math.Sqrt(i).ToString();
                case double d:
                    return Math.Truncate(d).ToString();
                case var o when (o?.ToString().Length ?? 0) == 0: // You can also use var here
                    return "Empty";
                case null: // Also check with null
                    throw new ArgumentNullException(paramName: nameof(element), message: "Element must not be null");
                default:
                    return string.Empty;
            }
        }

        public void RaiseException(string code)
        {// C# 6
            try
            {
                throw new ArgumentException(code);
            }
            catch (ArgumentException ae) when (ae.Message.Contains("100"))
            {// Type and value
                System.Console.WriteLine($"Error => {ae.Message}");
            }
            catch (ArgumentException ae) when (ae.Message.Contains("200"))
            {// Type and value
                System.Console.WriteLine($"Error => {ae.Message}");
            }
            catch (ArgumentException ae)
            {// Any other ArgumentException not included before
                System.Console.WriteLine($"Error => {ae.Message}");
            }
        }

        public enum Options { First, Second, Third, Fourth };
        public Color ExpressionPatterns() =>
            Console.BackgroundColor switch
            {
                ConsoleColor.Red => Color.FromArgb(255, 0, 0),
                ConsoleColor.Green => Color.FromArgb(0, 255, 0),
                ConsoleColor.Blue => Color.FromArgb(0, 0, 255),
                ConsoleColor.Black => Color.FromArgb(255, 255, 255),
                _ => throw new ArgumentException("Invalid value")
            };


        public int PropertyExpression(Building p) =>
            p switch
            {
                { Age: 10 } => p.Age * 1,
                { Age: 20 } => p.Age * 2,
                _ => 30,
            };

        public static string SwitchTuple(string first, string second)
            => (first, second) switch
            {
                ("one", "two") => "Wins second",
                ("two", "one") => "Wins first",
                (_, _) => "tie"
            };

        public string PositionalPattern(Building building)
            => building switch
            {
                (0, "") => "No born",
                (15, "A") => "Young female",
                (25, "B") => "Too much older man",
                (_, _) => "No human",
                _ => "Unknown"
            };

        public Building ShortUsing()
        {
            using Building b = new Building()
            {
                Age = 20,
                State = "WA"
            };
            b.Age = 40;
            return b;
        }

        public object NullCoalescenceAsignment()
        {
            object a = null;
            a ??= "1";
            return a;
        }

        public string Indexes(Index i)
        {
            var numbers = new string[]
            {
                "One",
                "Two",
                "Three",
                "Four",
                "Five"
            };

            return numbers[i];
        }

        public string[] Ranges(Range r)
        {
            var numbers = new string[]
            {
                "One",
                "Two",
                "Three",
                "Four",
                "Five"
            };

            return numbers[r];
        }


        public static async IAsyncEnumerable<string> GenerateWord(string a)
        {
            for (int i = 65; i < 68; i++)
            {
                await Task.Delay(100);
                a += (char)i;
                yield return a;
            }
        }


        public class Building : IDisposable
        {
            public int Age { get; set; }
            public string State { get; set; }
            public void Deconstruct(out int age, out string state) // Magic method will be used when deconstruction
            {// It can be also an extension method
                age = Age;
                state = State.ToLower();
            }

            public void Dispose()
            {
                Age = 0;
            }
        }
    }
}
