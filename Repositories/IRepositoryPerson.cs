using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo_Asp_Mvc.Net.Models;

namespace Todo_Asp_Mvc.Net.Repositories
{
    public interface IRepositoryPerson : IDisposable
    {
        IEnumerable<Person> GetAll(int page, int pageSize);
        Person GetOne(int id);
        void Create(Person item);
        void CreateAll(IEnumerable<Person> items);
        void Update(Person item);
        bool Delete(int id);
        bool DeleteAll(IEnumerable<int> ids);
        int CountTotal();
    }
}
