using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted) {
            this.Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (this.Students.Count < 5) throw new InvalidOperationException();

            List<double> sorted = Students.Select(x => x.AverageGrade).ToList();

            double x = 0;
            foreach(double avgGrade in sorted)
            {
                if (avgGrade > averageGrade) x++;
            }

            double studentsCount = Convert.ToDouble(Students.Count);
            double perc = (x/(studentsCount-1))*100;

            if (perc <= 20)
                return 'A';
            else if (perc <= 40 && perc > 20)
                return 'B';
            else if (perc <= 60 && perc > 40)
                return 'C';
            else if (perc <= 80 && perc > 60) 
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
