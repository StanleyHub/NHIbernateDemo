using Autofac;
using Autofac.Integration.Mvc;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace DAL
{
    public class PersistencyModule : Module
    {
        private readonly string connectionString;

        public PersistencyModule(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            var sqlConnectionString = connectionString + ";Enlist=false;";
            var msSqlConfiguration = MsSqlConfiguration.MsSql2008.ConnectionString(sqlConnectionString).Raw("connection.release_mode", "on_close");
            var sessionFactory = Fluently.Configure().Database(msSqlConfiguration).Mappings(
                config => config.FluentMappings.AddFromAssembly(typeof (Project).Assembly)).BuildSessionFactory();
            builder.Register(c =>
                {
                    var session = sessionFactory.OpenSession();
                    session.FlushMode = FlushMode.Never;
                    return session;
                }).As<ISession>().InstancePerHttpRequest();
        }
    }
}
