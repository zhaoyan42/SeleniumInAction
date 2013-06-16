using System.Collections.Generic;

namespace Domain
{
    public class Class
    {
        private IList<Student> students;

        public Class()
        {
        }

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual IEnumerable<Student> Students
        {
            get { return students; }
        }

        public virtual void add_student(Student student)
        {
            students.Add(student);
        }
    }
}