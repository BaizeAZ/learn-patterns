using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Student
    {
        private string name;
        private int age;
        private string address;
        private string password;
        public Student() { }
        public Student(Student origin)
        {
            name = origin.name;
            age = origin.age;
            address = origin.address;
            password = origin.password;
        }
        public Student(string _name,int _age,string _address,string _ps)
        {
            name = _name;
            age = _age;
            address = _address;
            password = _ps;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Passward
        {
            get { return password; }
            set { password = value; }
        }
    }
}
