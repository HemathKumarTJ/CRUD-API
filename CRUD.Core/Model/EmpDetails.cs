using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Crud.Core.Model
{
    public class EmpDetails
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int Age { get; set; }
        public string Experience { get; set; }
        public long ContactNumber { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public int? LocationId { get; set; }

        public string? WorkLocation { get; set; }

        public string? Date { get; set; }  //convert date string
    }
}
