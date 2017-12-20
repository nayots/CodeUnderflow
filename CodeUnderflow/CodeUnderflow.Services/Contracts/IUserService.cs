using CodeUnderflow.Services.Models.Admin;
using System.Collections.Generic;

namespace CodeUnderflow.Services.Contracts
{
    public interface IUserService
    {
        IEnumerable<UserRoleInfo> All(string username, string role);

        bool UserExistsById(string userId);

        bool RoleExists(string role);

        void AddRoleToUser(string userId, string role);

        void RemoveRoleToUser(string userId, string role);

        void SuspendUser(string userId);

        void ReinstateUser(string userId);

        bool CheckIfDeleted(string username);
    }
}