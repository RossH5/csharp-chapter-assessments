using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_14a
{
    class Student
    {
        static int studentCount = 0;
        private string name;
        private string course;
        private string subject;
        private string university;
        private string email;
        private string phone;

        public Student()
        {
            studentCount++;
        }

        public Student(string name, string email, string phone)
        {
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
            studentCount++;
        }

        public Student(string name, string course, string subject, string university, string email, string phone)
        {
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
            this.Course = course;
            this.Subject = subject;
            this.University = university;
            studentCount++;
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
               "Phone: {5}\n" +
               "Total Student Count: {6}", Name, Course, Subject, University, Email, Phone, studentCount);
        }
    }
    class StudentTest
    {
        static Student StudentOne;
        static Student StudentTwo;
        static Student StudentThree;

        private Student Student1 { get; set; }
        private Student Student2 { get; set; }
        private Student Student3 { get; set; }

        static StudentTest()
        {
            StudentOne = new Student("Ross Henke", "Marine Biology", "Science", "University of Missouri", "rosshenke@email.com", "8675309");
            StudentTwo = new Student("Joe Bob", "Calculus", "Math", "University of Missouri", "joebob@email.com", "123-4567");
            StudentThree = new Student("Jill Bob", "Rocket Science", "Science", "University of Missouri", "jillbob@email.com", "123-4577");
        }

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
            StudentOne.InfoDisplay();
            StudentTwo.InfoDisplay();
            StudentThree.InfoDisplay();
        }
    }
}
