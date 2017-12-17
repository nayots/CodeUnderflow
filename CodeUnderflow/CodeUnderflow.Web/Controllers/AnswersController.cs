using CodeUnderflow.Common.Extensions;
using CodeUnderflow.Services.Contracts;
using CodeUnderflow.Web.Models.AnswersViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeUnderflow.Web.Controllers
{
    public class AnswersController : Controller
    {
        private IUserService userService;
        private IQuestionsService questionsService;
        private IAnswersService answersService;

        public AnswersController(IUserService userService, IQuestionsService questionsService, IAnswersService answersService)
        {
            this.userService = userService;
            this.questionsService = questionsService;
            this.answersService = answersService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult New(NewAnswerModel newAnswerModel)
        {
            if (this.ModelState.IsValid && this.questionsService.Exists(newAnswerModel.QuestionId.Value))
            {
                this.answersService.Create(newAnswerModel.QuestionId.Value, this.User.GetUserId(), newAnswerModel.Content, DateTime.UtcNow);
                
                return RedirectToAction("Details", "Questions", new { id = newAnswerModel.QuestionId });
            }

            return BadRequest();
        }
    }
}
