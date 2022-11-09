using Crud.Core.IRepositories;
using Crud.Core.Model;
using Crud.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Repositories.Repositories
{
    public class EmpDetailsRepository : IEmpDetailsRepository
    {
        private readonly CRUDContext _crudcontext;
        public EmpDetailsRepository(CRUDContext crudcontext)
        {
            _crudcontext = crudcontext;
        }

        #region CREATE
        public void CreateDetails(EmpDetails empdetails)
        {
            if (empdetails != null)
            {
                if (empdetails.EmployeeId == 0)
                {
                    EmployeeDetails employeedetails = new EmployeeDetails();
                    employeedetails.First_Name = empdetails.FirstName;
                    employeedetails.Last_Name = empdetails.LastName;
                    employeedetails.Date_Of_Joining = DateTime.Parse(empdetails.Date);
                    employeedetails.Age = empdetails.Age;
                    employeedetails.Experience = empdetails.Experience;
                    employeedetails.Contact_Number = empdetails.ContactNumber;
                    employeedetails.Address = empdetails.Address;
                    employeedetails.Location_Id = empdetails.LocationId;
                    employeedetails.Password = empdetails.Password;
                    employeedetails.Confirm_Password = empdetails.ConfirmPassword;
                    employeedetails.Created_Time_Stamp = DateTime.Now;
                    employeedetails.Updated_Time_Stamp = DateTime.Now;
                    _crudcontext.Add(employeedetails);
                    _crudcontext.SaveChanges();
                }
                else
                {
                    var item = _crudcontext.EmployeeDetails.Where(a => a.Employee_Id == empdetails.EmployeeId).SingleOrDefault();
                    if (item != null)
                    {
                        item.First_Name = empdetails.FirstName;
                        item.Last_Name = empdetails.LastName;
                        item.Date_Of_Joining = DateTime.Parse(empdetails.Date);
                        item.Age = empdetails.Age;
                        item.Experience = empdetails.Experience;
                        item.Contact_Number = empdetails.ContactNumber;
                        item.Address = empdetails.Address;

                        item.Location_Id = empdetails.LocationId;

                        item.Password = empdetails.Password;
                        item.Confirm_Password = empdetails.ConfirmPassword;
                        item.Updated_Time_Stamp = DateTime.Now;
                        _crudcontext.SaveChanges();
                    }
                }
            }
        }
        #endregion

        #region READ/LIST
        public List<EmpDetails> Readlist()
        {
            List<EmpDetails> model = new List<EmpDetails>();
            var data = _crudcontext.EmployeeDetails.Where(a => a.Is_Deleted == false).ToList();
            if (data != null)
            {
                foreach (var item in data)
                {
                    EmpDetails empdetails = new EmpDetails();
                    empdetails.EmployeeId = item.Employee_Id;
                    empdetails.FirstName = item.First_Name;
                    empdetails.LastName = item.Last_Name;                                     
                    empdetails.Date = item.Date_Of_Joining.ToString("yyyy-MM-dd");
                    empdetails.Age = item.Age;
                    empdetails.Experience = item.Experience;
                    empdetails.ContactNumber = item.Contact_Number;
                    empdetails.Address = item.Address;
                    var value = item.Location_Id;
                    var section = _crudcontext.LocationDetails.Where(x => x.Location_Id == value).SingleOrDefault();
                    empdetails.WorkLocation = section.Work_Location;
                    empdetails.Password = item.Password;
                    empdetails.ConfirmPassword = item.Confirm_Password;
                    model.Add(empdetails);
                }
            }
            return model;
        }
        #endregion

        #region EDIT/UPDATE
        public EmpDetails Update(int id)
        {
            EmpDetails empdetails = new EmpDetails();
            var item = _crudcontext.EmployeeDetails.Where(a => a.Employee_Id == id).SingleOrDefault();
            empdetails.EmployeeId = item.Employee_Id;
            empdetails.FirstName = item.First_Name;
            empdetails.LastName = item.Last_Name;
            empdetails.Date = item.Date_Of_Joining.ToString("yyyy-MM-dd");
            empdetails.Age = item.Age;
            empdetails.Experience = item.Experience;
            empdetails.ContactNumber = item.Contact_Number;
            var ID = item.Location_Id;
            var place = _crudcontext.LocationDetails.Where(m => m.Location_Id == ID).SingleOrDefault();
            empdetails.WorkLocation = place.Work_Location;

            empdetails.LocationId = place.Location_Id;
            empdetails.Address = item.Address;
            empdetails.Password = item.Password;
            empdetails.ConfirmPassword = item.Confirm_Password;
            return empdetails;
        }
        #endregion

        #region DELETE
        public void DeleteDone(int id)
        {
            var item = _crudcontext.EmployeeDetails.Where(a => a.Employee_Id == id).SingleOrDefault();
            if (item != null)
            {
                item.Is_Deleted = true;
                _crudcontext.SaveChanges();
            }
        }
        #endregion

        #region SEARCH
        public List<EmpDetails> search(string search)
        {
            List<EmpDetails> model = new List<EmpDetails>();
            var data = _crudcontext.EmployeeDetails.Where(a => a.First_Name.Contains(search) && a.Is_Deleted == false).ToList();
            if (data != null)
            {
                foreach (var item in data)
                {
                    EmpDetails empdetails = new EmpDetails();
                    empdetails.EmployeeId = item.Employee_Id;
                    empdetails.FirstName = item.First_Name;
                    empdetails.LastName = item.Last_Name;
                    empdetails.Date = item.Date_Of_Joining.ToString("MM-dd-yyyy");
                    empdetails.Age = item.Age;
                    empdetails.Experience = item.Experience;
                    empdetails.ContactNumber = item.Contact_Number;
                    empdetails.Address = item.Address;
                    //var value = item.Location_Id;
                    empdetails.WorkLocation = _crudcontext.LocationDetails.Where(x => x.Location_Id == item.Location_Id).Select(a=>a.Work_Location).SingleOrDefault();

                    //empdetails.WorkLocation = section.Work_Location;
                    empdetails.Password = item.Password;
                    empdetails.ConfirmPassword = item.Confirm_Password;
                    model.Add(empdetails);
                }
            }
            return model;
        }
        #endregion

        #region DETAILS
        public EmpDetails Details(int id)
        {
            EmpDetails empdetails = new EmpDetails();
            var item = _crudcontext.EmployeeDetails.Where(a => a.Employee_Id == id).SingleOrDefault();
            if (item != null)
            {
                empdetails.EmployeeId = item.Employee_Id;
                empdetails.FirstName = item.First_Name;
                empdetails.LastName = item.Last_Name;
                empdetails.Date = item.Date_Of_Joining.ToString("MM-dd-yyyy"); ;
                empdetails.Age = item.Age;
                empdetails.Experience = item.Experience;
                empdetails.ContactNumber = item.Contact_Number;
                empdetails.Address = item.Address;
                var value = item.Location_Id;
                var section = _crudcontext.LocationDetails.Where(x => x.Location_Id == value).SingleOrDefault();
                empdetails.WorkLocation = section.Work_Location;
                empdetails.Password = item.Password;
                empdetails.ConfirmPassword = item.Confirm_Password;
            }
            return empdetails;
        }
        #endregion

        #region DropDown(create)
        public List<LocDetails> GetDropDown()
        {
            List<LocDetails> model = new List<LocDetails>();
            var data = _crudcontext.LocationDetails.Where(a => a.Is_Deleted == false).ToList();
            if (data != null)
            {
                foreach (var item in data)
                {
                    LocDetails locdetails = new LocDetails();
                    locdetails.LocationId = item.Location_Id;
                    locdetails.WorkLocation = item.Work_Location;
                    model.Add(locdetails);
                }
            }
            return model;
        }
        #endregion



    }
}
