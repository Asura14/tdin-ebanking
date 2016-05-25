using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerA
{
    public class Company
    {
        int id;
        string name;
        decimal currentStockPrice;

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

        public decimal CurrentStockPrice
        {
            get
            {
                return currentStockPrice;
            }

            set
            {
                currentStockPrice = value;
            }
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
