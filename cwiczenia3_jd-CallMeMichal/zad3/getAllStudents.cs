using zad3.Models;

namespace zad3
{
    public class getAllStudents
    {

        public List<Student> getStudentList(String _dataFilePath)
        {

            string[] lines = System.IO.File.ReadAllLines(_dataFilePath);
            List<Student> students = new List<Student>();
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');
                if (fields.Length == 9)
                {
                    Student student = new Student
                    {
                        Name = fields[0],
                        Surname = fields[1],
                        Study = new()
                        {
                            Name = fields[2],
                            Mode = fields[3]
                        },
                        Index = int.Parse(fields[4]),
                        BirthDate = DateTime.Parse(fields[5]),
                        Email = fields[6],
                        MotherName = fields[7],
                        FatherName = fields[8]
                    };
                    students.Add(student);
                };

            }
            
            return students;
        }

    }
   


}
