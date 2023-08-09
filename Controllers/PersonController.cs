using System;
using System.Web.Mvc;
using Todo_Asp_Mvc.Net.Data;
using Todo_Asp_Mvc.Net.Models;
using Todo_Asp_Mvc.Net.Repositories;
using Todo_Asp_Mvc.Net.Services;

namespace Todo_Asp_Mvc.Net.Controllers
{
    [HandleError]
    public class PersonController : Controller
    {
        private IRepositoryPerson _repositoryPerson =  new RepositoryPerson(new Todo_Asp_MvcNetContext());
        private IRepositoryAdresse _repoAdresse = new RepositoryAdresse(new Todo_Asp_MvcNetContext());
        private Messagerie  messagerie = new Messagerie();

        // GET: Person
        public ActionResult Index(int page =1, int pageSize =10)
        {
            var _countTotal = _repositoryPerson.CountTotal();
            Metadata _metadata = new Metadata
            {
                HasNext = _countTotal > (pageSize * page),
                HasPrev = page != 1,
                CurrentPage = page,
                PageSize = pageSize,
                PrevPage = (page > 1) ? (page - 1) : 1,
                NextPage = page + 1,
                TotalPages = _countTotal / pageSize
            };
            ViewBag.Title = "Liste persons";
            ViewBag.CountTotal = _countTotal;
            ViewBag.Metadata = _metadata;
            var result = _repositoryPerson.GetAll(page, pageSize);
            return View(result);
        }
        // create a person
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Title = "Creation Personne";
            ViewBag.Adresses = _repoAdresse.GetAll();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nom,Prenom,DateNaissance,AdresseId")] Person item)
        {
            if (ModelState.IsValid)
            {
            _repositoryPerson.Create(item);
            this.Flash("Création d'une personne avec succès.",FlashLevel.Success);
            return RedirectToAction("Index");
            }
            this.Flash("Verifier les entrées .", FlashLevel.Danger);
            ViewBag.Adresses = _repoAdresse.GetAll();
            return View(item);
        }
        public ActionResult Show(int id)
        {
            ViewBag.Title = "Affichage d'une personne";
            var result = _repositoryPerson.GetOne(id);
            return View(result);
        }
        public ActionResult Delete(int id)
        {
            var result = _repositoryPerson.Delete(id);
            if(result == true)
            {
                this.Flash("La suppression a été un succès.",FlashLevel.Success);
                return RedirectToAction("Index");
            }
            this.Flash("Erreur de suppression. Réessayer",FlashLevel.Danger);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Person itemUpdated)
        {
            _repositoryPerson.Update(itemUpdated);
            this.Flash("La modification a été un succès.", FlashLevel.Success);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Modification d'une personne";
            ViewBag.Adresses = _repoAdresse.GetAll();
            var result = _repositoryPerson.GetOne(id);
            return View(result);
        }
        public void Export()
        {
            var list = _repositoryPerson.GetAll(1,1000);
            var csv = String.Format("Nom;Prenom;Date de Naissance;Adresse;Date de création;Date de modification");
            // datas to share
            foreach(var item in list)
            {
                csv += "\r\n";
                csv += String.Format(" {0};{1};{2};{3};{4};{5};",
                    item.Nom,item.Prenom,
                    ShortDate((DateTime)item.DateNaissance),
                    $"{item.Adresse.Angle} {item.Adresse.Rue}  {item.Adresse.Name}",
                    ShortDate((DateTime)item.CreatedAt),
                    ShortDate((DateTime)item.UpdatedAt)
                    );
            }
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", $"attachment;filename=Liste_Personnes_{DateTime.UtcNow.ToShortDateString()}.csv");
            Response.Charset = "utf-8";
            Response.ContentType = "application/text";
            Response.Output.Write(csv);
            Response.Flush();
            Response.End();
        }

        public ActionResult SendEmail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendEmail(int id,[Bind(Include = "Titre,Message")] MessageEmail item)
        {
            messagerie.SendEmail(item);
            return View();
        }
        public ActionResult ExportPdf()
        {
            return RedirectToAction("Index");
        }

        protected string ShortDate(DateTime date)
        {
            return date.ToShortDateString();
        }
    }
}