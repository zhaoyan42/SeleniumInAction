namespace TargetMvcApplication.Models
{
    public class Student
    {
        public Student()
        {
            
        }
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Number { get; set; }
    }
}