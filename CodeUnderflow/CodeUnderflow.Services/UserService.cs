using AutoMapper.QueryableExtensions;
using CodeUnderflow.Data.Models;
using CodeUnderflow.Services.Contracts;
using CodeUnderflow.Services.Models.Admin;
using CodeUnderflow.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeUnderflow.Services
{
    public class UserService : IUserService
    {
        private CodeUnderflowDbContext db;
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;

        public UserService(CodeUnderflowDbContext db, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void AddRoleToUser(string userId, string role)
        {
            var user = this.db.Users.First(u => u.Id == userId);
            Task.Run(async () =>
            {
                var userRoles = await this.userManager.GetRolesAsync(user);

                if (!userRoles.Contains(role) && await this.roleManager.RoleExistsAsync(role))
                {
                    await this.userManager.AddToRoleAsync(user, role);
                }
            }).Wait();
        }

        public IEnumerable<UserRoleInfo> All(string username, string role)
        {
            username = username is null ? "" : username.Trim();

            List<UserRoleInfo> users = this.db.Users.Where(u => u.UserName.Contains(username)).ProjectTo<UserRoleInfo>().ToList();

            for (int i = 0; i < users.Count; i++)
            {
                Task.Run(async () =>
                {
                    var user = await this.userManager.FindByIdAsync(users[i].Id);

                    var roles = await this.userManager.GetRolesAsync(user);

                    users[i].Roles = roles;
                }).Wait();
            }

            if (role != null && role.Length > 1)
            {
                users = users.Where(u => u.Roles.Contains(role)).ToList();
            }

            return users;
        }

        public bool CheckIfDeleted(string username)
        {
            return this.db.Users.Where(u => u.UserName == username && u.IsDeleted).Count() > 0;
        }

        public void ReinstateUser(string userId)
        {
            var user = this.db.Users.First(u => u.Id == userId);
            user.IsDeleted = false;
            this.db.SaveChanges();
        }

        public void RemoveRoleToUser(string userId, string role)
        {
            var user = this.db.Users.First(u => u.Id == userId);
            Task.Run(async () =>
            {
                var userRoles = await this.userManager.GetRolesAsync(user);

                if (userRoles.Contains(role) && await this.roleManager.RoleExistsAsync(role))
                {
                    await this.userManager.RemoveFromRoleAsync(user, role);
                }
            }).Wait();
        }

        public bool RoleExists(string role)
        {
            return Task.Run(async () => await this.roleManager.RoleExistsAsync(role)).Result;
        }

        public void SuspendUser(string userId)
        {
            var user = this.db.Users.First(u => u.Id == userId);
            user.IsDeleted = true;
            this.db.SaveChanges();
            Task.Run(async () =>
            {
                await this.userManager.UpdateSecurityStampAsync(user);
            }).Wait();
        }

        public bool UserExistsById(string userId)
        {
            return this.db.Users.Any(u => u.Id == userId);
        }
    }
}