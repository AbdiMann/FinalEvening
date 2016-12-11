using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCEveining.ViewModels
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required,DataType(DataType.EmailAddress),Display(Name= "Addresses Of Employees")]
        public string Address { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

        //public int HumanId { get; set; }
        //public string HumanName { get; set; }
        //public string CountryName { get; set; }
    }
}