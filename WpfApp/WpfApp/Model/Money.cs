using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public class Money : IPair
    {
        public int Rubles { get; set; }
        public int Kopecks { get; set; }

        public Money(int rubles, int kopecks)
        {
            Rubles = rubles;
            Kopecks = kopecks;
            Normalize();
        }

        private void Normalize()
        {
            Rubles += Kopecks / 100;
            Kopecks %= 100;
            if (Kopecks < 0)
            {
                Kopecks += 100;
                Rubles -= 1;
            }
        }

        public IPair Add(IPair other)
        {
            if (other is Money otherMoney)
            {
                return new Money(Rubles + otherMoney.Rubles, Kopecks + otherMoney.Kopecks);
            }
            throw new ArgumentException("Invalid type of argument for Add operation");
        }

        public IPair Subtract(IPair other)
        {
            if (other is Money otherMoney)
            {
                return new Money(Rubles - otherMoney.Rubles, Kopecks - otherMoney.Kopecks);
            }
            throw new ArgumentException("Invalid type of argument for Subtract operation");
        }

        public IPair Multiply(IPair other)
        {
            if (other is Money otherMoney)
            {
                int totalKopecks1 = Rubles * 100 + Kopecks;
                int totalKopecks2 = otherMoney.Rubles * 100 + otherMoney.Kopecks;
                int resultKopecks = totalKopecks1 * totalKopecks2 / 100;
                return new Money(resultKopecks / 100, resultKopecks % 100);
            }
            throw new ArgumentException("Invalid type of argument for Multiply operation");
        }

        public IPair Divide(IPair other)
        {
            if (other is Money otherMoney)
            {
                int totalKopecks1 = Rubles * 100 + Kopecks;
                int totalKopecks2 = otherMoney.Rubles * 100 + otherMoney.Kopecks;
                if (totalKopecks2 == 0)
                {
                    throw new DivideByZeroException();
                }
                int resultKopecks = (totalKopecks1 * 100) / totalKopecks2;
                return new Money(resultKopecks / 100, resultKopecks % 100);
            }
            throw new ArgumentException("Invalid type of argument for Divide operation");
        }

        public override string ToString()
        {
            return $"{Rubles} руб. {Kopecks} коп.";
        }
    }

}
