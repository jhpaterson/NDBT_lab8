using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Linq;


namespace MappingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Employee).Assembly);
            var sessionFactory = cfg.BuildSessionFactory();

            using (ISession session = sessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                // query for addresses 
                Address add = session.Get<Address>(2);

                // query for employees
                ICriteria criteria = session.CreateCriteria<Employee>();
                IList<Employee> employees = criteria.List<Employee>();


                // wait for key press before ending
                Console.ReadLine();
            }

        }
    }
}
