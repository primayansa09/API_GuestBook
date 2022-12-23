using Buku_Absen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buku_Absen.Repository.Interface
{
    public interface IRepository
    {
        IEnumerable<Visitor> Get();

        Visitor Get(int key);
        int Insert(Visitor visitor);
        int update(Visitor visitor, int key);
        int Delete(int key);
    }
}
