﻿using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.GradeBooks;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class StandardGradeBook:BaseGradeBook
    {
        public GradeBookType Type { get; set; }
        public StandardGradeBook(string name, bool isWeighted) :base(name, isWeighted)
        {
            Type = GradeBookType.Standard;
        }
    }
}
