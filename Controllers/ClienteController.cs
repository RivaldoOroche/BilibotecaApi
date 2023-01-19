using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using Biblioteca.Cliente.Api.Routes;
using dominio = Biblioteca.Cliente.Dominio;

namespace Biblioteca.Cliente.Api.Controllers
{
    [ApiController]
    public class ClienteController : ControllerBase
    {
        //private ProductoQueryAll db = ProductoQueryAll();
        [HttpGet(Routes.ApiRoutes.RouteCliente.GetAll)]
        public IEnumerable<dominio.Entidades.Cliente> ListarClientes()
        {
            #region
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("biblioteca");
            var colecction = database.GetCollection<dominio.Entidades.Cliente>("cliente");
            #endregion

            var listaCliente = colecction.Find(x => true).ToList();
            return listaCliente;
        }
        [HttpGet(Routes.ApiRoutes.RouteCliente.GetById)]
        public dominio.Entidades.Cliente BuscarCliente(int id)
        {
            #region
            var client = new MongoClient("mongodb://localhost:27017");   

            var database = client.GetDatabase("biblioteca");
            var colecction = database.GetCollection<dominio.Entidades.Cliente>("cliente");
            #endregion

            var objCliente = colecction.Find(x => x.idCliente == id).FirstOrDefault();
            return objCliente;
        }

        [HttpPost(Routes.ApiRoutes.RouteCliente.Create)]
        public ActionResult<dominio.Entidades.Cliente> CrearCliente(dominio.Entidades.Cliente cliente)
        {
            #region
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("biblioteca");
            var colecction = database.GetCollection<dominio.Entidades.Cliente>("cliente");
            #endregion

            cliente._id=ObjectId.GenerateNewId().ToString();
            colecction.InsertOne(cliente);
            return Ok();
        }
        [HttpPut(Routes.ApiRoutes.RouteCliente.Update)]
        public ActionResult<dominio.Entidades.Cliente> ModificarCliente(dominio.Entidades.Cliente cliente)
        {
            #region
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("biblioteca");
            var colecction = database.GetCollection<dominio.Entidades.Cliente>("cliente");
            #endregion
            colecction.FindOneAndReplace(x => x._id == cliente._id, cliente);
            return Ok();
        }
        [HttpDelete(Routes.ApiRoutes.RouteCliente.Delete)]
        public ActionResult<dominio.Entidades.Cliente> EliminarCliente(int id)
        {
            #region
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("biblioteca");
            var colecction = database.GetCollection<dominio.Entidades.Cliente>("cliente");
            #endregion

            colecction.FindOneAndDelete(x=>x.idCliente== id);
            return Ok();
        }

    }
}
