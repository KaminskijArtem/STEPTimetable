using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestBCSETimeTableProj.DBDAO
{
    public class Lecturer
    {
        [Key]
        public int IdLecturer { get; set; }
        public string NameLecturer { get; set; }
        public int IdChair { get; set; }

        public Chair Chair { get; set; }
        public List<Record> Record { get; set; }
    }
}
