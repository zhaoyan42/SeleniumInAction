using Domain;
using FluentNHibernate.Mapping;

namespace ORM.NHibernate
{
    public class ClassMap:ClassMap<Class>
    {
        public ClassMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            HasMany(x => x.Students).Access.LowerCaseField().Cascade.All();
        }
    }
}