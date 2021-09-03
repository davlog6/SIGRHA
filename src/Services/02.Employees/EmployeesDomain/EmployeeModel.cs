using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeesDomain
{
    public class EmployeeModel
    {
        [Key]
        public int IdEmployees { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }

}
