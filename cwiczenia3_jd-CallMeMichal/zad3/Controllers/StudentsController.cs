using Microsoft.AspNetCore.Mvc;
using zad3.Models;

namespace zad3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class HomeController : ControllerBase
    {
        getAllStudents getstudents = new();



        private const string _dataFilePath = "dane1.csv";


        //koncowki to metody w klasie
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = getstudents.getStudentList(_dataFilePath);

            return Ok(students);
        }

        [HttpGet("{index}")]
        public IActionResult GetStudents(String index)
        {

            var students = getstudents.getStudentList(_dataFilePath);

            var student = students.FirstOrDefault(x => x.Index == int.Parse(index));

            return Ok(student);
        }



        [HttpDelete("{index}")]
        public IActionResult DeleteStudents(String index)
        {

            var students = getstudents.getStudentList(_dataFilePath);

            var student = students.FirstOrDefault(x => x.Index == int.Parse(index));

            if (student != null)
            {
                students.Remove(student);
                return Ok(student);
            }
            else
                return NotFound();


        }


        [HttpPut("{index}")]
        public IActionResult PutStudents(String index, [FromBody] Student student)
        {

            var students = getstudents.getStudentList(_dataFilePath);

            var studentOnly = students.FirstOrDefault(x => x.Index == int.Parse(index));

            if (students != null)
            {
                studentOnly.Name = student.Name;
                studentOnly.Surname = student.Surname;
                studentOnly.Study.Name = student.Study.Name;
                studentOnly.Study.Mode = student.Study.Mode;
                studentOnly.Index = student.Index;
                studentOnly.BirthDate = student.BirthDate;
                studentOnly.Email = student.Email;
                studentOnly.MotherName = student.MotherName;
                studentOnly.FatherName = student.FatherName;

            }
            else
            {
                return NotFound();
            }

            using (StreamWriter stream = new FileInfo(_dataFilePath).AppendText())
            {
                stream.WriteLine(student);

            }


            return Ok(student);
        }


        [HttpPost]
        public IActionResult PostStudents([FromBody] Student student)
        {
            var students = getstudents.getStudentList(_dataFilePath);

            students.Add(student);

            using (var streamWriter = new StreamWriter(_dataFilePath, true))
            {
                streamWriter.WriteLine(student);

            }
            using (StreamWriter stream = new FileInfo(_dataFilePath).AppendText())
            {
                stream.WriteLine(student);

            }


            return Ok(student);
        }







    }


}
