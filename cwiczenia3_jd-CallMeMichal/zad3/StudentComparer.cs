using zad3.Models;

namespace zad3
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
