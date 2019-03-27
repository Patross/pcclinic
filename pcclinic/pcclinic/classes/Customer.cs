using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pcclinic.classes
{
    class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }


        private Customer()
        {

        }
        public Customer(string firstName, string lastName, string email, string telephone) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Telephone = telephone;

        }

    }
}
