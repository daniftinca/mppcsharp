using lab_c.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_csharp.service
{
    interface ILoginService
    {
        User findByUsername(String username);

        bool loginUser(String username, String parola);

    }
}
