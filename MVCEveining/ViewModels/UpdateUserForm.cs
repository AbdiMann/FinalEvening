using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCEveining.ViewModels
{
    public class UpdateUserForm
    {
        public UpdateUserForm() : this(null) { }

        public UpdateUserForm(LoginForm user)
        {
            if (user == null) return;
            this.UserName = user.UserName;
            this.Password = user.Password;
            this.CurrentPermissions = user.CurrentPermissions;

        }

        public int Id { get; set; }
        [Required]
        public LoginForm.Permissions CurrentPermissions { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public string HashedPassword(string Password)
        {
#pragma warning disable 618
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Password, "SHA1");
#pragma warning restore 618
        }
    }

}