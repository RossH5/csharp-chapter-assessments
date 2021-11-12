using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_14a
{
    class Student
    {
        private string name;
        private string course;
        private string subject;
        private string university;
        private string email;
        private string phone;

        public Student()
        {

        }

        public Student(string name, string email, string phone)
        {
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
        }

        public Student(string name, string course, string subject, string university, string email, string phone)
        {
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
            this.Course = course;
            this.Subject = subject;
            this.University = university;
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Course
        {
            get { return course; }
            set { course = value; }
        }
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        public string University
        {
            get { return university; }
            set { university = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public void InfoDisplay()
        {
            Console.WriteLine("Name: {0}\n" +
               "Course: {1}\n" +
               "Subject: {2}\n" +
               "University: {3}\n" +
               "Email: {4}\n" +
               "Phone: {5}", Name, Course, Subject, University, Email, Phone);
        }
    }
    class StudentTest
    {
        private Student student1;
        private Student student2;
        private Student student3;

        private Student Student1 { get => student1; set => student1 = value; }
        private Student Student2 { get => student2; set => student2 = value; }
        private Student Student3 { get => student3; set => student3 = value; }

        public StudentTest () 
        { 
        }

        public StudentTest (Student studentOne, Student studentTwo, Student studentThree)
        {
            Student1 = studentOne;
            Student2 = studentTwo;
            Student3 = studentThree;
        }
        public void Printer()
        {
            student1.InfoDisplay();
            student2.InfoDisplay();
            student3.InfoDisplay();
        }
    }
}
