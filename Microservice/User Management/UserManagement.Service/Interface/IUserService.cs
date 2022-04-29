using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Models.Login;
using UserManagement.Models.Register;
using UserManagement.Models.UpdatePassword;

namespace UserManagement.Service.Interface
{
    public interface IUserService
    {
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<UserDetails> LoginAsync(Login users);

        /// <summary>
        /// Update Password
        /// </summary>
        /// <param name="updatePassword"></param>
        /// <returns></returns>
        Task<UpdatePasswordResponse> UpdatePasswordAync(UpdatePassword updatePassword);

        /// <summary>
        /// Register User
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// /<param name="userDetail"></param>
        /// <returns></returns>
        Task<RegisterResponse> Register(string email, string password, Users userDetail);

    }
}
