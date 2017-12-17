using CodeUnderflow.Common;
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

        [HttpPost]
        [Authorize]
        public IActionResult Delete(DeleteAnswerModel deleteAnswerModel)
        {
            if (this.ModelState.IsValid 
                && deleteAnswerModel.AnswerId != null 
                && this.answersService.Exists(deleteAnswerModel.AnswerId.Value) 
                && (this.answersService.UserCanEdit(deleteAnswerModel.AnswerId.Value, this.User.GetUserId()) 
                    || this.User.IsInRole(GlobalConstants.AdminRoleName) 
                    || this.User.IsInRole(GlobalConstants.ModeratorRoleName)))
            {
                this.answersService.Delete(deleteAnswerModel.AnswerId.Value);

                return this.RedirectToAction("Details", "Questions", new { id = deleteAnswerModel.QuestionId.Value });
            }

            return BadRequest();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int? answerId, int? questionId)
        {
            if (answerId != null && questionId != null 
                && this.answersService.Exists(answerId.Value) 
                && this.questionsService.Exists(questionId.Value) 
                && (this.answersService.UserCanEdit(answerId.Value, this.User.GetUserId()) 
                    || this.User.IsInRole(GlobalConstants.AdminRoleName) 
                    || this.User.IsInRole(GlobalConstants.ModeratorRoleName)))
            {
                EditAnswerModel model = new EditAnswerModel();
                model.QuestionId = questionId.Value;
                model.Content = this.answersService.GetAnswerContent(answerId.Value);

                return View(model);
            }

            return BadRequest();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(EditAnswerModel editAnswerModel)
        {
            if (this.ModelState.IsValid
                 && this.answersService.Exists(editAnswerModel.AnswerId.Value)
                && this.questionsService.Exists(editAnswerModel.QuestionId.Value)
                && (this.answersService.UserCanEdit(editAnswerModel.AnswerId.Value, this.User.GetUserId())
                    || this.User.IsInRole(GlobalConstants.AdminRoleName)
                    || this.User.IsInRole(GlobalConstants.ModeratorRoleName)))
            {
                this.answersService.Update(editAnswerModel.AnswerId.Value, editAnswerModel.Content);

                return RedirectToAction("Details", "Questions", new { id = editAnswerModel.QuestionId.Value });
            }

            return View(editAnswerModel);
        }
    }
}
