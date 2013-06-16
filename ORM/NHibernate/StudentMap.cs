using Domain;
using FluentNHibernate.Mapping;

namespace ORM.NHibernate
{
    public class StudentMap:ClassMap<Student>
    {
        public StudentMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Number);
        }
    }
}