using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace OJTProject.Dal
{
    public class Logs
    {
        public virtual int Id { get; set; }
        public virtual string Content { get; set; }
        public virtual DateTime Transdate { get; set; }

        private static string ConnectionString()
        {
            return string.Empty;
        }

        /*START YOUR CODE AFTER THIS LINE*/

    }
}