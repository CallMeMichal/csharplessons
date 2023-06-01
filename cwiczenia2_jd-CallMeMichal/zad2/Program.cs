
using System.Globalization;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using zad2.Models;

namespace zad2
{
    public class Program
    {
        private static readonly string WorkingDir = Environment.CurrentDirectory;
        private static readonly string ProjectDir = Directory.GetParent(WorkingDir).Parent.Parent.FullName;
        private static int _columnNumber = 9;

        public static async Task Main(string[] args)
        {
            string path = args[0];
            string resultPath = args[1];
            string logsPath = @$"{ProjectDir}\Logs\logs.txt";

            FileInfo fileInfo = new(path);

            StudentComparer studentComparer = new();
            HashSet<Student> studentSet = new(studentComparer);

            await using StreamWriter streamWriter = new(logsPath);
            using StreamReader streamReader = new(fileInfo.OpenRead());

            string line;
            while ((line = await streamReader.ReadLineAsync()) != null)
            {
                string[] studentData = line.Split(",");

                if (studentData.Length != _columnNumber)
                {
                    await AppendLine(streamWriter, "Too small amount of columns");
                    continue;
                }

                string error = ValidateStudentData(studentData);
                if (!string.IsNullOrEmpty(error))
                {
                    await AppendLine(streamWriter, error);
                    continue;
                }

                Student student = CreateStudent(studentData);
                bool result = studentSet.Add(student);
                if (!result)
                {
                    await AppendLine(streamWriter, $"Student  {studentData[4]} is duplicated");
                }
            }

            string json = ParseToJson(studentSet);
            await using StreamWriter resultStreamWriter = new(resultPath);
            await AppendLine(resultStreamWriter, json);
        }

      

        private static Student CreateStudent(string[] elements)
        {
            return new Student
            {
                Name = elements[0],
                Surname = elements[1],
                Study = new()
                {
                    Name = elements[2],
                    Mode = elements[3]
                },
                Index = int.Parse(elements[4]),
                BirthDate = DateTime.Parse(elements[5]),
                Email = elements[6],
                MotherName = elements[7],
                FatherName = elements[8]
            };
        }

        private static string ParseToJson(HashSet<Student> students)
        {
            var result = new
            {
                CreatedAt = DateTime.Now,
                Author = "Michał Tulej",
                Data = students
            };

            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            return JsonSerializer.Serialize(result, options);
        }

        private static async Task AppendLine(StreamWriter streamWriter, string line)
        {
            await streamWriter.WriteLineAsync(line);
        }

        private static string ValidateStudentData(string[] studentData)
        {
            if (studentData.Length != 9)
            {
                return "Invalid number of columns";
            }

            if (string.IsNullOrWhiteSpace(studentData[0]))
            {
                return "Name is required";
            }

            if (string.IsNullOrWhiteSpace(studentData[1]))
            {
                return "Surname is required";
            }

            if (string.IsNullOrWhiteSpace(studentData[2]))
            {
                return "Study name is required";
            }

            if (string.IsNullOrWhiteSpace(studentData[3]))
            {
                return "Study mode is required";
            }
            //out słuzy do wskazania ze indeks jest parametrem wyjsciowym , zmienne nie jest inicjowana przez przekazaniem do int , jej wartosc jest ustawiana przez metode jesli zakonczy sie pomyslnie

            if (!int.TryParse(studentData[4], out int index) || index <= 0)
            {
                return "Invalid index number";
            }
            if (!DateTime.TryParseExact(studentData[5], "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                return "Invalid date of birth. The correct format is yyyy-MM-dd";
            }

            if (!Regex.IsMatch(studentData[6], @"@pjwstk.edu.pl"))
            {
                return "Invalid email address. The correct format is @pjwstk.edu.pl";
            }

            if (string.IsNullOrWhiteSpace(studentData[7]))
            {
                return "Mother name is required";
            }

            if (string.IsNullOrWhiteSpace(studentData[8]))
            {
                return "Father name is required";
            }

            return null;
        }

  
    }


}

