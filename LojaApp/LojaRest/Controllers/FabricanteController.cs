using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LojaRest.Controllers
{
    public class FabricanteController : ApiController
    {
        // GET api/fabricante
        public IEnumerable<Models.Fabricante> Get()
        {
            Models.LojaDataContext dc = new Models.LojaDataContext();
            var r = from f in dc.Fabricantes select f;
            return r.ToList();
        }

        // POST api/fabricante
        public void Post([FromBody] string value)
        {
            List<Models.Fabricante> x = JsonConvert.DeserializeObject
            <List<Models.Fabricante>>(value);
            Models.LojaDataContext dc = new Models.LojaDataContext();
            dc.Fabricantes.InsertAllOnSubmit(x);
            dc.SubmitChanges();
        }

        // PUT api/fabricante/5
        public void Put(int id, [FromBody] string value)
        {
            Models.Fabricante x = JsonConvert.DeserializeObject
            <Models.Fabricante>(value);
            Models.LojaDataContext dc = new Models.LojaDataContext();
            Models.Fabricante fab = (from f in dc.Fabricantes
                                     where f.Id == id
                                     select f).Single();
            fab.Descricao = x.Descricao;
            dc.SubmitChanges();
        }

        // DELETE api/fabricante/5
        public void Delete(int id)
        {
            Models.LojaDataContext dc = new Models.LojaDataContext();
            Models.Fabricante fab = (from f in dc.Fabricantes
                                     where f.Id == id
                                     select f).Single();
            dc.Fabricantes.DeleteOnSubmit(fab);
            dc.SubmitChanges();
        }
    }
}
