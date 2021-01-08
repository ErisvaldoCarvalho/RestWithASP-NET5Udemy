using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository.Generic;
using System;
using System.Linq;

namespace RestWithASPNETUdemy.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(MySQLContext context):base(context) { }

        public Person Disable(long id)
        {
            var person = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            if (person != null)
            {
                person.Enabled = false;
                try
                {
                    _context.Entry(person).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return person;
        }
    }
}
