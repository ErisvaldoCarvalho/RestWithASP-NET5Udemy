using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Hypermedia.Abastract
{
    public interface IResponseEnricher
    {
        bool CanEnrich(ResultExecutingContext context);
        Task Enrich(ResultExecutingContext context);
    }
}
