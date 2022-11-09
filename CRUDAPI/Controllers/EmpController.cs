using Crud.Core.IServices;
using Crud.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace CrudAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmpController : Controller
    {
        private readonly IEmpDetailsService _iempdetailsservice;
        public EmpController(IEmpDetailsService iempdetailsservice)
        {
            _iempdetailsservice = iempdetailsservice;
        }

        #region CREATE
        [HttpPost]
        public IActionResult Create(EmpDetails empdetails)
        {
            _iempdetailsservice.CreateDetails(empdetails);
            return RedirectToAction("Create");
        }
        #endregion

        #region READ/LIST
        [HttpGet]
        public IActionResult Read()
        {
            var value = _iempdetailsservice.Readlist();
            return Ok(value);
        }
        #endregion

        #region EDIT/UPDATE
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value = _iempdetailsservice.Update(id);
            return Ok(value);
        }
        #endregion

        #region DELETE
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _iempdetailsservice.DeleteDone(id);
            return RedirectToAction("Read");
        }
        #endregion

        #region SEARCH 
        [HttpGet]
        public IActionResult Search(string search)
        {
            var value = _iempdetailsservice.search(search);
            return Ok(value);
        }
        #endregion

        #region DETAIL
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var value = _iempdetailsservice.Details(id);
            return Ok(value);
        }
        #endregion

        #region  Create(DropDown)
        [HttpGet]
        public IActionResult Create()
        {
            var value = _iempdetailsservice.GetDropDown();
            return Ok(value);
        }
        #endregion

    }
}
