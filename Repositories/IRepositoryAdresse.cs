using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo_Asp_Mvc.Net.Models;

namespace Todo_Asp_Mvc.Net.Repositories
{
    public interface IRepositoryAdresse : IDisposable
    {
        IEnumerable<Adresse> GetAll();
        Adresse GetOne(int id);
        void Create(Adresse item);
        void CreateAll(IEnumerable<Adresse> items);
        void Update(Adresse item);
        bool Delete(int id);
        bool DeleteAll(IEnumerable<int> ids);
    }
}
