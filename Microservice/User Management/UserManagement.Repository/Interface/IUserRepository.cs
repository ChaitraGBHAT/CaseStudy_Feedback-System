using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Models.Login;
using UserManagement.Models.Register;
using UserManagement.Models.UpdatePassword;

namespace UserManagement.Repository.Interface
{
    public interface IUserRepository
    {
        Task<UserDetails> Login(Login users);

        Task<UpdatePasswordResponse> UpdatePasswordAync(UpdatePassword updatePassword);

       Task<RegisterResponse> Register(string email, string password, string roleName);
    }
}

