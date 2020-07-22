using Gym2.Models;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Gym2.Controllers
{
    public class ClientiController : ControllerBase
    {
        public int idSala = 1;

        // GET: Clienti
        public ActionResult Index()
        {

            var model = new ClientiIndexModel();
            model.ClientItems = new List<ClientiIndexModel.ClientItem>();

            //citire din bd

            var list = Db.ClientList.Include(x=>x.AbonamentList).Where(x => x.Sters == null || x.Sters == false).ToList();

            foreach (var itemDb in list)
            {
                model.ClientItems.Add(new ClientiIndexModel.ClientItem()
                {
                    Nume = itemDb.Nume,
                    Prenume = itemDb.Prenume,
                    IdClient = itemDb.IdClient,
                    IdSala = itemDb.IdSala,
                    IdUtilizator = itemDb.IdUtilizator,
                    AreAbonamentCurent = itemDb.AbonamentList.Any(y => y.DataFinalizare >= DateTime.Now && y.DataInceput <= DateTime.Now)
                }); ;
            }

            return View(model);
        }
       
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {

            Client clientDb = await Db.ClientList.FirstOrDefaultAsync(x => x.IdClient == id);

            var model = new ClientEditViewModel();
            model.IdClient = id;
            model.Nume = clientDb.Nume;
            model.IdUtilizator = clientDb.IdUtilizator;
            model.Prenume = clientDb.Prenume;

            //

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ClientEditViewModel model)
        {
            Client clientDb = await Db.ClientList.FirstOrDefaultAsync(x => x.IdClient == model.IdClient);


            return null;
        }


    }




}