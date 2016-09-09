using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TheParkingLot.Models;

namespace TheParkingLot.DataAccess
{
    public class AdminDataAccess
    {
        string _connectionString = string.Empty;

        public AdminDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }
        
    }
}
