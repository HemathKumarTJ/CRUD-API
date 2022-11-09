using Crud.Core.Model;
using Crud.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRUD.Controllers
{
    public class EmployeeController : Controller
    {

        #region CREATE
        [HttpGet]
        public IActionResult Create()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7160/api/Emp/Create");
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadFromJsonAsync<IList<LocDetails>>();
                    readTask.Wait();
                    ViewBag.Location = readTask.Result;

                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmpDetails empdetails)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7160/api/Emp/Create");
                var Posttask = client.PostAsJsonAsync(client.BaseAddress, empdetails);
                Posttask.Wait();
                var result = Posttask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Read");
                }
            }
            return RedirectToAction("Read");
        }
        #endregion

        #region READ/LIST
        public IActionResult Read()
        {
            List<EmpDetails> studdetails = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7160/api/Emp/Read");
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<IList<EmpDetails>>();
                    readTask.Wait();
                    studdetails = (List<EmpDetails>?)readTask.Result;
                }
                List<EmpDetails> sort = studdetails.OrderBy(a => a.FirstName).ToList();
                return View(sort);
            }
        }
        #endregion

        #region EDIT/UPDATE
        public IActionResult Edit(int id)
        {
            Create();
            EmpDetails student = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7160/api/Emp/Edit?id=");
                var responseTask = client.GetAsync(client.BaseAddress + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<EmpDetails>();
                    readTask.Wait();
                    student = readTask.Result;
                }
            }
            return View("Create", student);
        }
        #endregion

        #region DELETE
        public IActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7160/api/Emp/Delete?id=");
                //HTTP DELETE
                var deleteTask = client.DeleteAsync(client.BaseAddress + id.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Read");
                }
            }
            return RedirectToAction("Read");
        }
        #endregion

        #region SEARCH
        public IActionResult Search(string search)
        {
            //if (!string.IsNullOrWhiteSpace(search))
            //{
            List<EmpDetails> studdetails = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7160/api/Emp/Search?search=");
                var responseTask = client.GetAsync(client.BaseAddress + search);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<IList<EmpDetails>>();
                    readTask.Wait();
                    studdetails = (List<EmpDetails>?)readTask.Result;
                }
                //List<EmpDetails> sort = studdetails.OrderBy(a => a.FirstName).ToList();
                //return View("Read", sort);
                return View("Read",studdetails);
            }
            //}
            //else
            //{
            //    return RedirectToAction("Read");
            //}
        }
        #endregion

        #region DETAIL
        public IActionResult Detail(int id)
        {
            EmpDetails empdetails = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7160/api/Emp/Detail?id=");
                var responseTask = client.GetAsync(client.BaseAddress + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<EmpDetails>();
                    readTask.Wait();
                    empdetails = readTask.Result;
                }
            }
            return View(empdetails);
        }
        #endregion

    }
}
