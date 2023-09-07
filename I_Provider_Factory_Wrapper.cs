using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_07_09
{
    internal interface I_Provider_Factory_Wrapper
    {
        DbConnection CreateConnection();
        string Connection_string { get; set; }
    }
}
