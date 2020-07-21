using Gym2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gym2.Controllers
{
    public class ClientiController : ControllerBase
    {
        public int idSala = 1;

        // GET: Clienti
        [AllowAnonymous]
        public ActionResult Index()
        {
          
            var model = new ClientiIndexModel();
            model.ClientItems = new List<ClientiIndexModel.ClientItem>();

            //citire din bd

            var list = Db.ClientList.Where(x => x.IdSala == idSala).ToList();

            //select * from Client
            //foreach(var itemDb in list)
            //{
            //    model.ClientItems.Add(new ClientiIndexModel.ClientItem()
            //    {
            //        Nume = itemDb.Nume,
            //        Prenume=itemDb.Prenume,
            //        IdClient=itemDb.Id,
            //        IdSala=itemDb.IdSala,
            //        IdUtilizator=itemDb.IdUtilizator
            //    });
            //}

            var test = Db.AbonamentList.ToList();

            model.ClientItems.Add(new ClientiIndexModel.ClientItem()
            {
                Nume = "Adrian",
                Prenume = "Domenteanu",
                IdClient=1,
                IdUtilizator=1,
                IdSala=1
            });
            model.ClientItems.Add(new ClientiIndexModel.ClientItem()
            {
                Nume = "Alex",
                Prenume = "Pop",
                IdClient = 2,
                IdUtilizator = 2,
                IdSala = 1
            });
            model.ClientItems.Add(new ClientiIndexModel.ClientItem()
            {
                Nume = "Ana",
                Prenume = "Popa",
                IdClient = 3,
                IdUtilizator = 3,
                IdSala = 2
            });

            return View(model);
        }
       
    }
}