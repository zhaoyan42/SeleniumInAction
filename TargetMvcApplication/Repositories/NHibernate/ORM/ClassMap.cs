using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using TargetMvcApplication.Models;

namespace TargetMvcApplication.DBMaps
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