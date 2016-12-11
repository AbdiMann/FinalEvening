using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEveining.ViewModels
{
    public class PersonClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }





        public List<PersonClass> GetPersonInfo()
        {
            return new List<PersonClass>
            {
                new PersonClass {
                    ID = 1,
                    Name = "ahmed",
                    Address = "Hargeisa",
                    Phone = "123456"
                },
                 new PersonClass {
                    ID = 1,
                    Name = "Abdi",
                    Address = "Hargeisa",
                    Phone = "123456"
                },
                  new PersonClass {
                    ID = 1,
                    Name = "Ali",
                    Address = "Hargeisa",
                    Phone = "123456"
                },

                new PersonClass {
                    ID = 1,
                    Name = "hebel",
                    Address = "Hargeisa",
                    Phone = "123456"
                },



        };
        }
    }
}