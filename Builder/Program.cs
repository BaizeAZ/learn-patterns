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
        static Student CreateStudent(StudentBuilder builder)
        {
            builder.BuildName("he");
            builder.BuildAge(16);
            builder.BuildAddress("adfasdfa");
            builder.BuildPassward("6666666");
            return builder.GetStudent();
        }
    }
}
