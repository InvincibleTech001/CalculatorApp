using System;
using CalculatorApp.Models;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            bool keepRunning = true;

            Console.WriteLine("=== Welcome to CalculatorApp ===\n");

            while (keepRunning)
            {
                try
                {
                    if (calculator.CurrentState == CurrentState.FirstNumber)
                    {
                        Console.Write("Enter first number: ");
                        var firstInput = Console.ReadLine();
calculator.FirstNumber = double.TryParse(firstInput, out double fNum) ? fNum : 0;
                        calculator.CurrentState = CurrentState.SecondNumber;
                    }

                    Console.Write("Enter operator (+, -, *, /): ");
                    var operatorInput = Console.ReadLine();
                    calculator.MathOperator = operatorInput ?? string.Empty;

                    Console.Write("Enter second number: ");
                    var secondInput = Console.ReadLine();
                    calculator.SecondNumber = double.TryParse(secondInput, out double sNum) ? sNum : 0;

                    calculator.Calculate();

                    Console.WriteLine($"\nResult: {calculator.Result}");
                    Console.WriteLine($"Equation: {calculator.Equation}\n");

                    Console.Write("Press 'C' to clear, 'CE' to clear entry, or 'Enter' to continue with result: ");
                    var inputRaw = Console.ReadLine();
                    var input = inputRaw != null ? inputRaw.Trim().ToUpper() : string.Empty;

                    if (input == "C")
                        calculator.Clear();
                    else if (input == "CE")
                        calculator.ClearEntry();
                    else
                        calculator.CurrentState = CurrentState.SecondNumber; // continue using result

                    Console.Write("Do you want to exit? (y/n): ");
                    var exitInput = Console.ReadLine();
                    var exit = exitInput != null ? exitInput.Trim().ToLower() : string.Empty;
                    if (exit == "y")
                        keepRunning = false;

                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    calculator.Clear(); // reset after error
                }
            }

            Console.WriteLine("Goodbye!");
        }
    }
}
