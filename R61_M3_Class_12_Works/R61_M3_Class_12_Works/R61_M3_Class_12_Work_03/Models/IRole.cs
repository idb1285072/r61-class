using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_12_Work_03.Models
{
    public interface IRole
    {
        void AddRoles(params string[] roles);
        string GetRoles();
    }
}
