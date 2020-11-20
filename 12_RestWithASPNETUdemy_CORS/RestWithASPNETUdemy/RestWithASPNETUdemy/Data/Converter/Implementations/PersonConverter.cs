using RestWithASPNETUdemy.Data.Converter.Contract;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model; 
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Data.Converter.Implementations
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public Person Parser(PersonVO origin)
        {
            if (origin == null) return null;

            return new Person()
            {
                Id = origin.Id,
                Andress = origin.Andress,
                FirstName = origin.FirstName,
                Gender = origin.Gender,
                LastName = origin.LastName
            };
        }

        public List<Person> Parser(List<PersonVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parser(item)).ToList();
        }

        public PersonVO Parser(Person origin)
        {
            if (origin == null) return null;

            return new PersonVO()
            {
                Id = origin.Id,
                Andress = origin.Andress,
                FirstName = origin.FirstName,
                Gender = origin.Gender,
                LastName = origin.LastName
            };
        }

        public List<PersonVO> Parser(List<Person> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parser(item)).ToList();
        }
    }
}
