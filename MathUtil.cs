namespace CalculatorApp.Models
{
    public static class MathUtil
    {
        public static double Add(double a, double b) => a + b;
        public static double Subtract(double a, double b) => a - b;
        public static double Multiply(double a, double b) => a * b;
        public static double Divide(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException("Cannot divide by zero.");
            return a / b;
        }

        public static double Percent(double a) => a / 100.0;
        public static double ToggleSign(double a) => -a;
    }
}
