using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zad2.Models;

namespace zad2
{
    public class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            return StringComparer
                .InvariantCultureIgnoreCase
                .Equals($"{x.Name} {x.Surname} {x.Index}", $"{y.Name} {y.Surname} {y.Index}");
        }

        public int GetHashCode(Student obj)
        {
            return obj.Index.GetHashCode();
        }
    }
}
