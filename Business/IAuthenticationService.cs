using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IAuthenticationService
    {
        void RegisterUser(string username, string password);
        string Login(string username, string password);
    }
}
