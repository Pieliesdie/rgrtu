namespace Common
{
    using System;
    using System.Collections.Generic;

    public partial class Users
    {

        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        //public virtual ICollection<Rewards> Rewards { get; set; }

    }
}
