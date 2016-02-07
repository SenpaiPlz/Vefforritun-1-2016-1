using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webprogramming_assignment_3
{
    class Fraction
    {
        private int Numerator;
        private int Denominator;

        public Fraction()
        {
            Numerator = 0;
            Denominator = 1;
        }

        public Fraction(string fraction)
        { 
            // Ensure the format is correct (i.e. "numerator/denominator": 
            int nSlashPos = fraction.IndexOf("/");
            if (nSlashPos == -1)
            {
                throw new ArgumentException();
            }
            Numerator = Convert.ToInt32(fraction.Substring(0, nSlashPos));
            Denominator = Convert.ToInt32(fraction.Substring(nSlashPos + 1));
            Normalize();
        }

        public void Normalize()
        {
            //Improved readability added comments
            int TempNum = 0, TempDenom = 0, i = 0, factor = 0;
            TempNum = Numerator;
            TempDenom = Denominator;
            while (true)
            {
                if ((i = TempNum % TempDenom) == 0)
                //Sets i to TempNum % Tempdenom, checks if 0
                {
                    factor = TempDenom;
                    break;
                }
                if ((TempDenom = TempDenom % TempNum) == 0)
                //Sets tempDenom = tempdenom % tempnum, checks if 0
                {
                    factor = TempNum;
                    break;
                }
                TempNum = i;
            }
            Numerator /= factor;
            Denominator /= factor;
            if (Denominator < 0)
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", Numerator, Denominator);
        }

        public static Fraction operator +(Fraction Fin1, Fraction Fin2)
        {
            Fraction Result = new Fraction();

            Result.Numerator = (Fin1.Numerator * Fin2.Denominator)+(Fin2.Numerator * Fin1.Denominator);
            Result.Denominator = (Fin1.Denominator * Fin2.Denominator);

            Result.Normalize();
            return Result;
        }

        public static Fraction operator -(Fraction Fin1, Fraction Fin2)
        {
            Fraction Result = new Fraction();

            Result.Numerator = (Fin1.Numerator * Fin2.Denominator) - (Fin2.Numerator * Fin1.Denominator);
            Result.Denominator = (Fin1.Denominator * Fin2.Denominator);

            Result.Normalize();
            return Result;
        }

        public static Fraction operator *(Fraction Fin1, Fraction Fin2)
        {
            Fraction Result = new Fraction();

            Result.Numerator = (Fin1.Numerator * Fin2.Numerator);
            Result.Denominator = (Fin1.Denominator * Fin2.Denominator);

            Result.Normalize();
            return Result;
        }

        public static Fraction operator /(Fraction Fin1, Fraction Fin2)
        {
            Fraction Result = new Fraction();

            Result.Numerator = (Fin1.Numerator * Fin2.Denominator);
            Result.Denominator = (Fin1.Denominator * Fin2.Numerator);

            Result.Normalize();
            return Result;
        }
    }
}
