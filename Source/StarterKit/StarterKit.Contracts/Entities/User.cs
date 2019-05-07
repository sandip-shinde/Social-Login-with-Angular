using System;
using System.Collections.Generic;
using System.Text;

namespace StarterKit.Contracts.Entities
{
    public class User
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public Contact ContactDetails {get; set;}
    }

    public class Contact
    {
        public string Email { get; set; }
    }

   
}
