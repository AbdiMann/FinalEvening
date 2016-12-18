using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCEveining.ViewModels
{
    public class Test
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public State MState { get; set; }
        public enum State
        {
            New,
            Frozen,
            UnderAudit
        }
        

       public struct Account
        {
            public string Name;
            public string Address;
            public int AccountNumer;
            public int Balance;
            public int OverDraft;
        };

         Account baasheAccount;


        
    }

}