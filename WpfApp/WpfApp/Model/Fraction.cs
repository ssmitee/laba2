using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public class Fraction : IPair
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero");
            }

            Numerator = numerator;
            Denominator = denominator;
            Normalize();
        }

        private void Normalize()
        {
            if (Denominator < 0)
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }
        }

        public IPair Add(IPair other)
        {
            if (other is Fraction otherFraction)
            {
                int newNumerator = Numerator * otherFraction.Denominator + otherFraction.Numerator * Denominator;
                int newDenominator = Denominator * otherFraction.Denominator;
                return new Fraction(newNumerator, newDenominator);
            }
            throw new ArgumentException("Invalid type of argument for Add operation");
        }

        public IPair Subtract(IPair other)
        {
            if (other is Fraction otherFraction)
            {
                int newNumerator = Numerator * otherFraction.Denominator - otherFraction.Numerator * Denominator;
                int newDenominator = Denominator * otherFraction.Denominator;
                return new Fraction(newNumerator, newDenominator);
            }
            throw new ArgumentException("Invalid type of argument for Subtract operation");
        }

        public IPair Multiply(IPair other)
        {
            if (other is Fraction otherFraction)
            {
                int newNumerator = Numerator * otherFraction.Numerator;
                int newDenominator = Denominator * otherFraction.Denominator;
                return new Fraction(newNumerator, newDenominator);
            }
            throw new ArgumentException("Invalid type of argument for Multiply operation");
        }

        public IPair Divide(IPair other)
        {
            if (other is Fraction otherFraction)
            {
                if (otherFraction.Numerator == 0)
                {
                    throw new DivideByZeroException();
                }
                int newNumerator = Numerator * otherFraction.Denominator;
                int newDenominator = Denominator * otherFraction.Numerator;
                return new Fraction(newNumerator, newDenominator);
            }
            throw new ArgumentException("Invalid type of argument for Divide operation");
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
    }


}
