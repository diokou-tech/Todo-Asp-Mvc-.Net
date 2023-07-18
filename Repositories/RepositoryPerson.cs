using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Todo_Asp_Mvc.Net.Data;
using Todo_Asp_Mvc.Net.Models;
namespace Todo_Asp_Mvc.Net.Repositories
{
    public class RepositoryPerson : IRepositoryPerson, IDisposable
    {

        private Todo_Asp_MvcNetContext _context;

        public RepositoryPerson(Todo_Asp_MvcNetContext context)
        {
            _context = context;
        }

        public void Create(Person item)
        {
            _context.Persons.Add(item);
            Save();
        }

        public void CreateAll(IEnumerable<Person> items)
        {
            _context.Persons.AddRange(items);
            Save();

        }

        public bool Delete(int id)
        {
            Person person = _context.Persons.Find(id);
            if (person != null)
            {
                var result = _context.Persons.Remove(person);
                Save();
                return true;
            }
            return false;
        }

        public bool DeleteAll(IEnumerable<int> ids)
        {
            var personList = _context.Persons.Where(per => ids.Contains(per.Id));
            if (personList != null)
            {
                _context.Persons.RemoveRange(personList);
                Save();
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAll()
        {
            var result = _context.Persons
                .Include(per => per.Adresse)
                .OrderBy(per => per.CreatedAt).ToList();
            return result;
        }

        public Person GetOne(int id)
        {
            var result = _context.Persons
                .Include(per => per.Adresse)
                .Where(per => per.Id == id)
                .SingleOrDefault();
            return result;
        }
        public void Update(Person item)
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