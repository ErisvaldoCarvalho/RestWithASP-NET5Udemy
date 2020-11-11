using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
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
        private readonly IBookRepository _repository;
        public BookBusinessImplementations(IBookRepository repository)
        {
            _repository = repository;
        }
        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

    }
}
