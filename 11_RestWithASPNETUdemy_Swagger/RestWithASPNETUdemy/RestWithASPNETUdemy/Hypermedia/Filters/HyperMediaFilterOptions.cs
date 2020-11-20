using RestWithASPNETUdemy.Hypermedia.Abastract;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
