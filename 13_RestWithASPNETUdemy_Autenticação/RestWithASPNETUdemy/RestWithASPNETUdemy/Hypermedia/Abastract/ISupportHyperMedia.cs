using System.Collections.Generic;

namespace RestWithASPNETUdemy.Hypermedia.Abastract
{
    public interface ISupportHyperMedia
    {
        List<HypermediaLink> Links { get; set; }
    }
}
