using RestWithASPNETUdemy.Data.Converter.Implementations;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class PersonBusinessImplementations : IPersonBusiness
    {
        private readonly IPersonRepository _repository;
        private readonly PersonConverter _converter;

        public PersonBusinessImplementations(IPersonRepository repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }
        public PersonVO Create(PersonVO person)
        {
            return _converter.Parser(_repository.Create(_converter.Parser(person)));
        }

        public List<PersonVO> FindAll()
        {
            return _converter.Parser(_repository.FindAll());
        }

        public PersonVO FindById(long id)
        {
            return _converter.Parser(_repository.FindById(id));
        }

        public PersonVO Update(PersonVO person)
        {
            return _converter.Parser(_repository.Update(_converter.Parser(person)));
        }
        public PersonVO Disable(long id)
        {
            var personEntity = _repository.Disable(id);
            return _converter.Parser(personEntity);
        }
        public void Delete(long id)
        {
            _repository.Delete(id);
        }

    }
}
