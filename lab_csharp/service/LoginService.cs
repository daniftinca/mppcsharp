using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_c.Model;
using lab_c.Repository;

namespace lab_csharp.service
{
    public class LoginService : ILoginService
    {
        private UserRepository arbitruRepository;

        public LoginService(UserRepository arbitruRepository)
        {
            this.arbitruRepository = arbitruRepository;
        }

        public User findByUsername(string username)
        {
            return arbitruRepository.findByUsername(username);
        }

        public bool loginUser(string username, string parola)
        {
            User arbitru = arbitruRepository.findByUsername(username);
            if (arbitru == null)
            {
                return false;
            }
            else
            {
                return arbitru.Password.Equals(parola);
            }
        }
    }
}
