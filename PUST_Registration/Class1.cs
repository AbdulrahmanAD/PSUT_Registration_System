using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visual_project
{
     class Student
    {
        private string name;
        private int id;
        private int age;
        private string major;
        private int first;
        private int second;
        private int final;
        private int total;

        public Student()
        {
            name = " ";
            id = 0;
            age = 0;
            major = "NULL";
            first = 0;
            second = 0;
            final = 0;
            total = 0;
        }

        public string Name { get { return name; }set { name = value;     } }
        public int ID {  get {  return id; } set { id = value; } }

        public int Age {  get {  return age; } set { age = value; } }
        public string Major {  get {  return major; } set { major = value; } }
        public int First { get { return first; } set { first = value;  } }
        public int Second { get { return second; } set { second = value; } }
        public int Final { get { return final; } set { final = value; } }
        public int Total { get { return total; }  set { total = value; } }



    }
}
