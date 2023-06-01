using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2.Models
{
    public class JsonResult
    {
        public DateTime CreatedAt { get; set; }

        public string Author { get; set; }

        public HashSet<Student> Students { get; set; }
    }
}
