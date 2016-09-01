using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class dbconnection
    {
        public string connection_string = DataAccessLayer.Properties.Settings.Default.cn;
    }
}
