using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Core.Model
{
    public class LocDetails
    {
        public int LocationId { get; set; }
        public string? WorkLocation { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created_Time_Stamp { get; set; }
        public DateTime Updated_Time_Stamp { get; set; }
    }
}
