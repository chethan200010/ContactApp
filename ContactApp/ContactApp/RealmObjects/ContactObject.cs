using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.RealmObjects
{
    public class ContactObject : RealmObject
    {
        [PrimaryKey] public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
    }
}
