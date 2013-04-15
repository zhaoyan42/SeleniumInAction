using System.Collections.Generic;
using Domain;
using NHibernate;
using ORM.NHibernate.ORM;

namespace TargetMvcApplication.Presentation.ApplicationServices
{
    public class ClassService
    {
        protected ISession Session { get; set; }

        public ClassService()
        {
            Session = SessionProvider.Instance.get_session();
        }

        public void create_class(Class @class)
        {
            Session.Save(@class);
            Session.Flush();
        }

        public Class get_class(int id)
        {
            return Session.Get<Class>(id);
        }

        public IEnumerable<Class> get_all_classes()
        {
            return Session.CreateCriteria(typeof(Class)).List<Class>();
        }

        public void add_student(int id, Student student)
        {
            var transaction = Session.BeginTransaction();
            var @class = Session.Get<Class>(id);
            Session.Save(student);

            @class.add_student(student);
            Session.Update(@class);
            transaction.Commit();
        }
    }
}