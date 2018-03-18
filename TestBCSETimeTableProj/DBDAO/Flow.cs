using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestBCSETimeTableProj.DBDAO
{
    public class Flow
    {
        [Key]
        public int IdFlow { get; set; }
        public string Name { get; set; }

        public List<Group> Group { get; set; }
    }
}