﻿using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Hypermedia.Constants;
using System.Text;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Hypermedia.Enricher
{
    public class PersonEnricher : ContentResponseEnricher<PersonVO>
    {
        private readonly object _lock = new object();
        protected override Task EnrichModel(PersonVO content, IUrlHelper urlHelper)
        {
            var path = "api/person/v1";
            string link = GetLink(content.Id, urlHelper, path);

            content.Links.Add(new HypermediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = link,
                Rel = RelationTypes.self,
                Type = ResponseTypeFormat.DefaultGet
            });

            content.Links.Add(new HypermediaLink()
            {
                Action = HttpActionVerb.POST,
                Href = link,
                Rel = RelationTypes.self,
                Type = ResponseTypeFormat.DefaultPost
            });

            content.Links.Add(new HypermediaLink()
            {
                Action = HttpActionVerb.PUT,
                Href = link,
                Rel = RelationTypes.self,
                Type = ResponseTypeFormat.DefaultPut
            });

            content.Links.Add(new HypermediaLink()
            {
                Action = HttpActionVerb.PATCH,
                Href = link,
                Rel = RelationTypes.self,
                Type = ResponseTypeFormat.DefaultPatch
            });

            content.Links.Add(new HypermediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = link,
                Rel = RelationTypes.self,
                Type = "int"
            });
            return Task.FromResult<object>(null);
            //return null;
        }

        private string GetLink(long id, IUrlHelper urlHelper, string path)
        {
            lock (_lock)
            {
                var url = new { controller = path, id = id };
                return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2F", "/").ToString();
            };
        }
    }
}
