using CodeUnderflow.Common;
using CodeUnderflow.Common.Extensions;
using CodeUnderflow.Data.Models;
using CodeUnderflow.Services.Contracts;
using CodeUnderflow.Web.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeUnderflow.Web.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        private IUserService userService;
        private readonly SignInManager<User> _signInManager;

        public AdminController(IUserService userService, SignInManager<User> signInManager)
        {
            this.userService = userService;
            this._signInManager = signInManager;
        }

        public IActionResult All(string username, string role = "")
        {
            this.ViewData["selectedRole"] = role;

            var users = this.userService.All(username, role);

            return View(users);
        }

        [HttpPost]
        public IActionResult AddRole(string userId, string role)
        {
            if (userId != null && role != null)
            {
                if (this.userService.UserExistsById(userId) && this.userService.RoleExists(role))
                {
                    this.userService.AddRoleToUser(userId, role);
                }
            }
            else
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public IActionResult RemoveRole(string userId, string role)
        {
            if (userId != null || role != null)
            {
                if (this.userService.UserExistsById(userId) && this.userService.RoleExists(role))
                {
                    this.userService.RemoveRoleToUser(userId, role);

                    if (this.User.GetUserId().Equals(userId, StringComparison.OrdinalIgnoreCase) && role == GlobalConstants.AdminRoleName)
                    {
                        Task.Run(async () =>
                        {
                            await _signInManager.SignOutAsync();
                        }).Wait();

                        return RedirectToAction(nameof(HomeController.Index), "Home", new {area = "" });
                    }
                }
            }
            else
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public IActionResult Suspend(string userId)
        {
            if (userId != null)
            {
                if (this.userService.UserExistsById(userId))
                {
                    this.userService.SuspendUser(userId);
                }
            }
            else
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public IActionResult Reinstate(string userId)
        {
            if (userId != null)
            {
                if (this.userService.UserExistsById(userId))
                {
                    this.userService.ReinstateUser(userId);
                }
            }
            else
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }
    }
}
