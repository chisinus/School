using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.WebUI.Infrastracture.Abstract
{
    public interface IAuthProvider
    {
        bool Authenticate(string name, string pasword);
    }
}
