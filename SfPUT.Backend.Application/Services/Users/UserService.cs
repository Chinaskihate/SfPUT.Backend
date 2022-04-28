using System;
using System.Threading.Tasks;
using SfPUT.Backend.Application.Interfaces.Users;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.Application.Services.Users
{
    public class UserService : IUserService
    {
        // TODO#3: implement after identity server.
        public Task<User> GetUserById(Guid id)
        {
            // TODO#9: throw user not found exc.
            throw new NotImplementedException();
        }

        // TODO#3: implement after identity server.
        public Task<User> GetAdminById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
