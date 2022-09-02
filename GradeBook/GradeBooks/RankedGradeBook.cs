using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.GradeBooks;
using GradeBook.Enums;
using System.Linq;

namespace GradeBook.GradeBooks
{
   public class RankedGradeBook:BaseGradeBook
    {
        public GradeBookType Type { get; set; }
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            IEnumerable<double> squares = Enumerable.Range(1, 100).Select(x => (double)x);

            if (Students.Count < 5)
               {
                throw new InvalidOperationException();
               }
            else
            {
                if (averageGrade >= Percentile(squares, 80))
                    return 'A';
                else if (averageGrade >= Percentile(squares, 60))
                    return 'B';
                else if (averageGrade >= Percentile(squares, 40))
                    return 'C';
                else if (averageGrade >= Percentile(squares, 20))
                    return 'D';
                else
                    return 'F';
            }
        }

        public static double Percentile(IEnumerable<double> seq, double percentile)
        {
            var elements = seq.ToArray();
            Array.Sort(elements);
            double realIndex = percentile * (elements.Length - 1);
            int index = (int)realIndex;
            double frac = realIndex - index;
            if (index + 1 < elements.Length)
                return elements[index] * (1 - frac) + elements[index + 1] * frac;
            else
                return elements[index];
        }

    }
}
