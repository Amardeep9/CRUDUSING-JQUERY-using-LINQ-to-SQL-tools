using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudUsingJQueryUpdated.Models
{
    public class EmployeeInfo
    {
        public int EmpID;

        [Required(ErrorMessage = "Can not be blank Name")]
        public string EmpName { get; set; }

        [Required(ErrorMessage = "Can not be blank Contact")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Can not be blank Email Id")]
        public string EmailId { get; set; }
    }
}