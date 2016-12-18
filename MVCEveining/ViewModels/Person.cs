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


        [Required]
        public HttpPostedFileBase Image { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Image != null)
            {
                if (!Image.ContentType.Equals("image/jpeg"))
                {
                    yield return new ValidationResult("Only jpg files allowed.", new string[] { "Image" });
                }

                if (Image.ContentLength >= (4096 * 4096))
                {
                    yield return new ValidationResult("Signature must be less than 1 MB.", new List<string> { "Image" });
                }
            }
        }


        //[Required]
        //public HttpPostedFileBase Image { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (Image != null)
        //    {
        //        if (!Image.ContentType.Equals("image/jpeg"))
        //        {
        //            yield return new ValidationResult("Only jpg files allowed.", new string[] { "Image" });
        //        }

        //        if (Image.ContentLength >= (4096 * 4096))
        //        {
        //            yield return new ValidationResult("Signature must be less than 1 MB.", new List<string> { "Image" });
        //        }
        //    }
        //}
        //public int HumanId { get; set; }
        //public string HumanName { get; set; }
        //public string CountryName { get; set; }
    }
}