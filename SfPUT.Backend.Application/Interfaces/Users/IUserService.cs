using System;
using System.Threading.Tasks;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.Application.Interfaces.Users
{
    public interface IUserService
    {
        Task<User> GetUserById(Guid id);

        Task<User> GetAdminById(Guid id);
    }
}
