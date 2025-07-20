using System;

namespace CalculatorApp.Models
{
    public enum CurrentState
    {
        FirstNumber,
        SecondNumber
    }

    public class Calculator
    {
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public string MathOperator { get; set; }
        public string Result { get; private set; }
        public string Equation { get; private set; }

        public CurrentState CurrentState { get; set; } = CurrentState.FirstNumber;

        public Calculator()
        {
            FirstNumber = 0;
            SecondNumber = 0;
            MathOperator = "";
            Result = "";
            Equation = "";
        }

        public void Clear()
        {
            FirstNumber = 0;
            SecondNumber = 0;
            MathOperator = "";
            Result = "";
            Equation = "";
            CurrentState = CurrentState.FirstNumber;
        }

        public void ClearEntry()
        {
            if (CurrentState == CurrentState.FirstNumber)
                FirstNumber = 0;
            else
                SecondNumber = 0;
        }

        public void Calculate()
        {
            double output = 0;

            switch (MathOperator)
            {
                case "+":
                    output = MathUtil.Add(FirstNumber, SecondNumber);
                    break;
                case "-":
                    output = MathUtil.Subtract(FirstNumber, SecondNumber);
                    break;
                case "*":
                    output = MathUtil.Multiply(FirstNumber, SecondNumber);
                    break;
                case "/":
                    output = MathUtil.Divide(FirstNumber, SecondNumber);
                    break;
                default:
                    throw new InvalidOperationException("Unknown operator.");
            }

            Result = output.ToString();
            Equation = $"{FirstNumber} {MathOperator} {SecondNumber} = {Result}";

            // Prepare for next calculation
            FirstNumber = output;
            SecondNumber = 0;
            CurrentState = CurrentState.SecondNumber;
        }
    }
}
