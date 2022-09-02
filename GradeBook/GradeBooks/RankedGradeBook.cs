using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.GradeBooks;
using GradeBook.Enums;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
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
            var threshold = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (grades[threshold - 1] <= averageGrade)
                    return 'A';
            else if (grades[(threshold * 2) - 1] <= averageGrade)
                    return 'B';
            else if (grades[(threshold * 3) - 1] <= averageGrade)
                    return 'C';
            else if (grades[(threshold * 4) - 1] <= averageGrade)
                    return 'D';
            else
                return 'F';

        }
    }

}
