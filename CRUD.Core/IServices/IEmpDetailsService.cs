using Crud.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Core.IServices
{
    public interface IEmpDetailsService
    {
        void CreateDetails(EmpDetails empdetails);

        List<EmpDetails> Readlist();

        EmpDetails Update(int id);

        void DeleteDone(int id);

        List<EmpDetails> search(string search);

        EmpDetails Details(int id);

        List<LocDetails> GetDropDown();
    }
}
