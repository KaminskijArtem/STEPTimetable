using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestBCSETimeTableProj.DBDAO
{
    public class Faculty
    {
        [Key]
        public int IdFaculty { get; set; }
        public string NameFaculty { get; set; }

        public List<Group> Group { get; set; }
    }
}