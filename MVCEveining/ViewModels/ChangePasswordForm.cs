using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MVCEveining.Models;

namespace MVCEveining.ViewModels
{
    public class ChangePasswordForm
    {
        Repository repository = new Repository();


        public string UserName { get; set; }

        [Required, Display(Name = "Old Password")]
        public string OldPassword { get; set; }

        [Required, StringLength(32, MinimumLength = 8), Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [Required, StringLength(32, MinimumLength = 8), Display(Name = "Confirm New Password")]
        public string ConfirmNewPassword { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var username = HttpContext.Current.User.Identity.Name;

            if (!HttpContext.Current.User.Identity.Name.Equals(username))
            {
                yield return new ValidationResult("You can only change your own username.", new string[] { "Username" });
            }
            var identity = HttpContext.Current.User.Identity.Name.ToString();
            var user = repository.GetUserByLogin(identity);

            if (!user.Password.Equals((this.OldPassword)))
            {
                yield return new ValidationResult("Wrong old password.", new string[] { "OldPassword" });
            }

            if (this.NewPassword != null && !this.NewPassword.Equals(this.ConfirmNewPassword))
            {
                yield return new ValidationResult("New Password and Confirm New Password fields must match", new string[] { "ConfirmNewPassword" });
            }
        }
    }
}