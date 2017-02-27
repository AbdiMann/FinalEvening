using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCEveining.ViewModels
{
    public class LoginForm
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public Permissions CurrentPermissions { get; set; }

        public enum Permissions
        {
            None = 0,
            updateUsers = 1 << 0,
            CreateUsers = 1 << 1,
            RegisterCustomers = 1 << 2,
            CustomersLst = 1 << 3,
            Update = 1 << 4,
            Delete = 1 << 5
        }
    }
}