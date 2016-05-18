using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerA
{
    public class Order
    {
        int id;
        int client_id;
        string state;
        string type;
        double value;
        int quantity;
        DateTime creation_date;
        DateTime execution_date;

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

        public int Client_id
        {
            get
            {
                return client_id;
            }

            set
            {
                client_id = value;
            }
        }

        public string State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public double Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }

        public DateTime Creation_date
        {
            get
            {
                return creation_date;
            }

            set
            {
                creation_date = value;
            }
        }

        public DateTime Execution_date
        {
            get
            {
                return execution_date;
            }

            set
            {
                execution_date = value;
            }
        }
    }
}

