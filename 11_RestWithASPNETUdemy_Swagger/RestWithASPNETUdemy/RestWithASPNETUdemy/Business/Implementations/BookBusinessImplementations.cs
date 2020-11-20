using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using RestWithASPNETUdemy.Data.Converter.Implementations;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class BookBusinessImplementations : IBookBusiness
    {
        private readonly IRepository<Book> _repository;
        private readonly BookConverter _converter;
        public BookBusinessImplementations(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }
        public BookVO Create(BookVO book)
        {
            return _converter.Parser(_repository.Create(_converter.Parser(book)));
        }

        public List<BookVO> FindAll()
        {
            return _converter.Parser(_repository.FindAll());
        }

        public BookVO FindById(long id)
        {
            return _converter.Parser(_repository.FindById(id));
        }

        public BookVO Update(BookVO book)
        {
            return _converter.Parser(_repository.Update(_converter.Parser(book)));
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

    }
}
