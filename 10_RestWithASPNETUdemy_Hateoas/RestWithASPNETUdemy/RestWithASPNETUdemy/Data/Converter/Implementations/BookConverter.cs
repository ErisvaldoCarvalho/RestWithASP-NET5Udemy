using RestWithASPNETUdemy.Data.Converter.Contract;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Data.Converter.Implementations
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public BookVO Parser(Book origin)
        {
            return origin == null ? null :
                new BookVO()
                {
                    Author = origin.Author,
                    Id = origin.Id,
                    Launch_Date = origin.Launch_Date,
                    Price = origin.Price,
                    Title = origin.Title
                };
        }

        public List<BookVO> Parser(List<Book> origin)
        {
            return origin == null ? null : origin.Select(item => Parser(item)).ToList();
        }

        public Book Parser(BookVO origin)
        {
            return origin == null ? null :
                new Book()
                {
                    Author = origin.Author,
                    Id = origin.Id,
                    Launch_Date = origin.Launch_Date,
                    Price = origin.Price,
                    Title = origin.Title
                };
        }

        public List<Book> Parser(List<BookVO> origin)
        {
            return origin == null ? null : origin.Select(item => Parser(item)).ToList();
        }
    }
}
