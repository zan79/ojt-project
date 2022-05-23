using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace OJTProject.Dal
{
    public class Transaction
    {
        public virtual int Id { get; set; }
        public virtual int ProductId { get; set; }
        public virtual double Qty { get; set; }
        public virtual decimal ProductPrice { get; set; }
        public virtual decimal TotalPrice { get; set; }
        public virtual int CashierId { get; set; }
        public virtual DateTime Transdate { get; set; }

        private static string ConnectionString()
        {
            return string.Empty;
        }

        /*START YOUR CODE AFTER THIS LINE*/

    }
}