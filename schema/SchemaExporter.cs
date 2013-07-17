using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Engine;
using NHibernate.Tool.hbm2ddl;
using Xunit;

namespace schema
{
    public class SchemaExporter
    {
        [Fact]
        public void Export()
        {
            const string sqlConnectionString = "Data Source=localhost;Initial Catalog=project;Integrated Security=True;Enlist=false;";
            var msSqlConfiguration = MsSqlConfiguration.MsSql2008.ConnectionString(sqlConnectionString).Raw("connection.release_mode", "on_close");
            Configuration configuration = null;
            var sessionFactory = Fluently.Configure().Database(msSqlConfiguration).Mappings(
                config => config.FluentMappings.AddFromAssembly(typeof(Project).Assembly))
                                         .ExposeConfiguration(c =>
                                             {
                                                 configuration = c;
                                             }).BuildSessionFactory();
            var dbConnection = ((ISessionFactoryImplementor)sessionFactory).ConnectionProvider.GetConnection();
            var export = new SchemaExport(configuration);
            export.Execute(true, true, false, dbConnection, null);
        } 
    }
}
