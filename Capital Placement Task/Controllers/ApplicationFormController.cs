﻿using AutoMapper;
using Capital_Placement_Task.DTO;
using Capital_Placement_Task.Models;
using Capital_Placement_Task.Repositroy.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capital_Placement_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationFormController : ControllerBase
    {
        private readonly IBaseRepository<ApplicationForm> _context;

        public ApplicationFormController(IBaseRepository<ApplicationForm> context)
        {
            _context = context;
        }

        // GET: api/Program
        [HttpGet]
        public ActionResult<IEnumerable<object>> GetProgramApplications()
        {
            var ProgramApplications = _context.GetAll();

            return DTOForm(ProgramApplications); 

        }

        [HttpPut("{id}")]
        public IActionResult UpdateApplicationForm(int id, ApplicationForm updatedForm)
        {
            if (id != updatedForm.Id)
            {
                return BadRequest();
            }

            updatedForm = _context.Update(id, updatedForm);

            if (updatedForm == null)
            {
                return NotFound();
            }


            return NoContent();

        }

        private ActionResult<IEnumerable<object>> DTOForm(IEnumerable<ApplicationForm> ProgramApplications)
        {
            var result = ProgramApplications.Select(form =>
            {
                var questionObjects = form.Questions.Select(question =>
                {
                    object questionObject = null;

                    switch (question.QuestionType)
                    {
                        case QuestionType.Paragraph:
                            questionObject = new
                            {
                                Id = question.Id,
                                Title = question.Title,
                                BelongsTo = question.BelongsTo,
                                QuestionType = "Paragraph",
                                ParagraphValue = question.ParagraphValue,
                                Hide = question.Hide
                            };
                            break;
                        case QuestionType.ShortAnswer:
                            questionObject = new
                            {
                                Id = question.Id,
                                Title = question.Title,
                                BelongsTo = question.BelongsTo,
                                QuestionType = "ShortAnswer",
                                ShortAnswerValue = question.ShortAnswerValue,
                                Hide = question.Hide
                            };
                            break;
                        case QuestionType.MultipleChoice:
                            questionObject = new
                            {
                                Id = question.Id,
                                Title = question.Title,
                                BelongsTo = question.BelongsTo,
                                QuestionType = "MultipleChoice",
                                Choices = question.Choices,
                                Hide = question.Hide
                            };
                            break;
                        case QuestionType.YesNo:
                            questionObject = new
                            {
                                Id = question.Id,
                                Title = question.Title,
                                BelongsTo = question.BelongsTo,
                                QuestionType = "YesNo",
                                YesNo = question.YESNO,
                                Hide = question.Hide
                            };
                            break;
                        case QuestionType.Date:
                            questionObject = new
                            {
                                Id = question.Id,
                                Title = question.Title,
                                BelongsTo = question.BelongsTo,
                                QuestionType = "Date",
                                DatetValue = question.DatetValue,
                                Hide = question.Hide
                            };
                            break;
                        case QuestionType.Number:
                            questionObject = new
                            {
                                Id = question.Id,
                                Title = question.Title,
                                BelongsTo = question.BelongsTo,
                                QuestionType = "Number",
                                NumberValue = question.NumberValue,
                                Hide = question.Hide
                            };
                            break;
                        case QuestionType.Dropdown:
                            questionObject = new
                            {
                                Id = question.Id,
                                Title = question.Title,
                                BelongsTo = question.BelongsTo,
                                QuestionType = "Dropdown",
                                Options = question.Options,
                                Hide = question.Hide
                            };
                            break;
                        case QuestionType.FileUpload:
                            questionObject = new
                            {
                                Id = question.Id,
                                Title = question.Title,
                                BelongsTo = question.BelongsTo,
                                QuestionType = "FileUpload",
                                File = question.File,
                                Hide = question.Hide
                            };
                            break;
                    }

                    return questionObject;
                }).ToList();

                return new
                {
                    Id = form.Id,
                    Image = form.Image,
                    Questions = questionObjects
                };
            }).ToList();
            return result;
        }
    }
}
