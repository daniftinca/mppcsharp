using lab_c.Model;
using lab_csharp.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_csharp.controller
{
    public class LoginController
    {
        private LoginService loginService;

        
        public LoginController(LoginService loginService)
        {
            this.loginService = loginService;
        }

        public User findByUsername(String username)
        {
            return loginService.findByUsername(username);
        }

        public bool loginUser(String username, String password)
        {
            return loginService.loginUser(username, password);
        }

    }
}
