using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Todo_Asp_Mvc.Net.Data;
using Todo_Asp_Mvc.Net.Models;
namespace Todo_Asp_Mvc.Net.Repositories
{
    public class RepositoryAdresse : IRepositoryAdresse, IDisposable
    {

        private Todo_Asp_MvcNetContext _context;

        public RepositoryAdresse(Todo_Asp_MvcNetContext context)
        {
            _context = context;
        }

        public void Create(Adresse item)
        {
            _context.Adresses.Add(item);    
            Save();
        }

        public void CreateAll(IEnumerable<Adresse> items)
        {
            _context.Adresses.AddRange(items);
            Save();

        }

        public bool Delete(int id)
        {
            Adresse person = _context.Adresses.Find(id);
            if (person != null)
            {
                var result = _context.Adresses.Remove(person);
                Save();
                return true;
            }
            return false;
        }

        public bool DeleteAll(IEnumerable<int> ids)
        {
            var personList = _context.Adresses.Where(per => ids.Contains(per.Id));
            if (personList != null)
            {
                _context.Adresses.RemoveRange(personList);
                Save();
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            this.Dispose();
        }

        public IEnumerable<Adresse> GetAll()
        {
            var result = _context.Adresses
                .OrderBy(per => per.CreatedAt).ToList();
            return result;
        }

        public Adresse GetOne(int id)
        {
            var result = _context.Adresses
                .Where(per => per.Id == id)
                .SingleOrDefault();
            return result;
        }
        public void Update(Adresse item)
        {
            _context.Entry(item).State = EntityState.Modified;
            Save();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}