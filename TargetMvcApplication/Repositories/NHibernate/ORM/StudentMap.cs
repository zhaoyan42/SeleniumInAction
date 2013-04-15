using FluentNHibernate.Mapping;
using TargetMvcApplication.Models;

namespace TargetMvcApplication.DBMaps
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