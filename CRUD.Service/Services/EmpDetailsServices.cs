using Crud.Core.IRepositories;
using Crud.Core.IServices;
using Crud.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Service.Services
{
    public  class EmpDetailsServices : IEmpDetailsService
    {
        private readonly IEmpDetailsRepository _iempdetailsrepository;
        public EmpDetailsServices(IEmpDetailsRepository iempdetailsrepository)
        {
            _iempdetailsrepository = iempdetailsrepository;
        }

        #region CREATE
        public void CreateDetails(EmpDetails empdetails)
        {
            _iempdetailsrepository.CreateDetails(empdetails);
        }
        #endregion

        #region READ/LIST
        public List<EmpDetails> Readlist()
        {
            return _iempdetailsrepository.Readlist();
        }
        #endregion

        #region EDIT/UPDATE
        public EmpDetails Update(int id)
        {
            return _iempdetailsrepository.Update(id);
        }
        #endregion

        #region DELETE
        public void DeleteDone(int id)
        {
            _iempdetailsrepository.DeleteDone(id);
        }
        #endregion

        #region SEARCH
        public List<EmpDetails> search(string search)
        {
            return _iempdetailsrepository.search(search);
        }
        #endregion

        #region DETAILS
        public EmpDetails Details(int id)
        {
            return _iempdetailsrepository.Details(id);
        }
        #endregion

        #region DropDown(create)
        public List<LocDetails> GetDropDown()
        {
            return _iempdetailsrepository.GetDropDown();
        }
        #endregion
            
    }
}
