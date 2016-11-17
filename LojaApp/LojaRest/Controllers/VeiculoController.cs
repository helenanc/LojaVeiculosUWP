using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LojaRest.Controllers
{
    public class VeiculoController : ApiController
    {
        // GET api/veiculo
        internal IEnumerable<Models.Veiculo> Get()
        {
            Models.LojaDataContext dc = new Models.LojaDataContext();
            var r = from f in dc.Veiculos select f;
            return r.ToList();
        }

        // POST api/veiculo
        public void Post([FromBody] string value)
        {
            List<Models.Veiculo> x = JsonConvert.DeserializeObject
            <List<Models.Veiculo>>(value);
            Models.LojaDataContext dc = new Models.LojaDataContext();
            dc.Veiculos.InsertAllOnSubmit(x);
            dc.SubmitChanges();
        }

        // PUT api/fabricante/5
        public void Put(int id, [FromBody] string value)
        {
            Models.Veiculo x = JsonConvert.DeserializeObject
            <Models.Veiculo>(value);
            Models.LojaDataContext dc = new Models.LojaDataContext();
            Models.Veiculo veic = (from f in dc.Veiculos
                                   where f.Id == id
                                   select f).Single();
            veic.Ano = x.Ano;
            veic.Fabricante = x.Fabricante;
            veic.IdFabricante = x.IdFabricante;
            veic.Modelo = x.Modelo;
            veic.Vendido = x.Vendido;
            dc.SubmitChanges();
        }

        // DELETE api/veiculo/5
        public void Delete(int id)
        {
            Models.LojaDataContext dc = new Models.LojaDataContext();
            Models.Veiculo veic = (from f in dc.Veiculos
                                   where f.Id == id
                                   select f).Single();
            dc.Veiculos.DeleteOnSubmit(veic);
            dc.SubmitChanges();
        }
    }
}
