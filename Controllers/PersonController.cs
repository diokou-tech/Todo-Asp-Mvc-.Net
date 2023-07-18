using System.Web.Mvc;
using Todo_Asp_Mvc.Net.Data;
using Todo_Asp_Mvc.Net.Models;
using Todo_Asp_Mvc.Net.Repositories;

namespace Todo_Asp_Mvc.Net.Controllers
{
    public class PersonController : Controller
    {
        private IRepositoryPerson _repositoryPerson =  new RepositoryPerson(new Todo_Asp_MvcNetContext());
        private IRepositoryAdresse _repoAdresse = new RepositoryAdresse(new Todo_Asp_MvcNetContext());

        // GET: Person
        public ActionResult Index()
        {
            ViewBag.Title = "Liste persons";
            return View(_repositoryPerson.GetAll());
        }
        // crate a person
        public ActionResult Create()
        {
            ViewBag.Title = "Creation Personne";
            return View(_repoAdresse.GetAll());
        }
        [HttpPost]
        public ActionResult Store(Person item)
        {
            _repositoryPerson.Create(item);
            ViewBag.Title = "Liste persons";
            return View("Index", _repositoryPerson.GetAll());
        }
        public ActionResult Show(int id)
        {
            ViewBag.Title = "Affichge d'une personne";
            var result = _repositoryPerson.GetOne(id);
            return View(result);
        }
        public ActionResult Delete(int id)
        {
            var result = _repositoryPerson.Delete(id);
            if(result == true)
            {
                return View("Index", _repositoryPerson.GetAll());
            }
            return View("Index", _repositoryPerson.GetAll());
        }
        [HttpPost]
        public ActionResult Update(Person itemUpdated)
        {
            _repositoryPerson.Update(itemUpdated);
            return View("Index", _repositoryPerson.GetAll());
        }
        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Modification d'une personne";
            var result = _repositoryPerson.GetOne(id);
            return View(result);
        }
    }
}