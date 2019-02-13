﻿using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count<5)
            throw new InvalidOperationException("Ranked gradingrequires at least 5 students.");

            var treshold=(int)Math.Ceiling(Students.Count *0.2);
            var grades=Students.OrderByDescending(e=>e.AverageGrade).Select(e=>e.AverageGrade).ToList();
            if (grades[treshold-1]<=averageGrade)
            return 'A';
            else if (grades[(treshold*2)-1]<=averageGrade)
            return 'B';
            else if (grades[(treshold*3)-1]<=averageGrade)
            return 'C';
            else if (grades[(treshold*4)-1]<=averageGrade)
            return 'D';
            else 
            return 'F';
        return base.GetLetterGrade(averageGrade);
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
               Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistic()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
