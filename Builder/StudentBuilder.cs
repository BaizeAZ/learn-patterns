using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class StudentBuilder
    {
        private Student student;

        public StudentBuilder()
        {
            student = new Student();
        }
        public void BuildName(string name)
        {
            student.Name = name;            
        }
        public void BuildAge(int age)
        {
            student.Age = age;            
        }
        public void BuildAddress(string address)
        {
            student.Address = address;            
        }
        public void BuildPassward(string passward)
        {
            student.Passward = passward;            
        }
        public Student GetStudent()
        {
            return new Student(student);
        }
    }
}
