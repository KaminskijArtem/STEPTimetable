using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestBCSETimeTableProj.DBDAO
{
    public class Group
    {
        [Key]
        public int IdGroup { get; set; }
        public string NameGroup { get; set; }
        public int? IdFlow { get; set; }
        public int IdFaculty { get; set; }
        public int EduLevel { get; set; }

        public Faculty Faculty { get; set; }
        public Flow Flow { get; set; }
        public List<Record> Record { get; set; }
    }
}