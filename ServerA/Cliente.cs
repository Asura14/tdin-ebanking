using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerA
{
    public class Cliente
    {
        int id;
        string name;
        string email;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

    }
}
