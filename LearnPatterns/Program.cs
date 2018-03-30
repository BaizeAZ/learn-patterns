using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentBuilder builder = new StudentBuilder();
            Student student = CreateStudent(builder);
            Console.WriteLine(student.Age);
            Console.ReadKey();
        }
        static Student CreateStudent(StudentBuilder b)
        {
            b.BuildName("he");
            b.BuildAge(16);
            b.BuildAddress("adfasdfa");
            b.BuildPassward("6666666");
            return b.GetStudent();
        }
    }
}
