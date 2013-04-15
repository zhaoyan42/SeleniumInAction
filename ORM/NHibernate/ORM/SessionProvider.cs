using System.Configuration;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace ORM.NHibernate.ORM
{
    public class SessionProvider
    {
        private readonly Assembly assembly;
        private static ISessionFactory session_factory;
        private static SessionProvider _instance;
        private readonly object lock_flag = new object();
        public bool IsBuildSchema { get; set; }

        private SessionProvider(Assembly assembly)
        {
            this.assembly = assembly;
        }

        public ISessionFactory SessionFactory
        {
            get
            {
                if (session_factory == null)
                {
                    lock (lock_flag)
                    {
                        if (session_factory == null)
                        {
                            initilizae();
                        }
                    }
                }
                return session_factory;
            }
        }

        public void initilizae()
        {
            session_factory = Fluently.Configure().Database(MsSqlConfiguration.MsSql2000.ShowSql().ConnectionString(ConfigurationManager.ConnectionStrings["Database"].ConnectionString))
                                      .Mappings(m => m.FluentMappings.AddFromAssembly(assembly))
                                      .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "web"))
                                      .ExposeConfiguration(x =>
                                                           {
                                                               if (IsBuildSchema)
                                                               {
                                                                   new SchemaExport(x)
                                                                       .Execute(true, true, false);
                                                               }
                                                           })
                                      .BuildSessionFactory();
        }

        public static SessionProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SessionProvider(Assembly.GetAssembly(typeof(SessionProvider)));
                }
                return _instance;
            }
        }

        public ISession get_session()
        {
            return SessionFactory.OpenSession();
        }
    }
}