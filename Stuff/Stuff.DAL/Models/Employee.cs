using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stuff.DAL.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string MiddleName { get; set; }
        public string AmploymentDate { get; set; }
        public string Position { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}