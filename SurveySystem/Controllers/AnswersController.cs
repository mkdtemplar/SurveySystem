using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using midTerm.Data.DataTransferObjects;
using midTerm.Data.Entities;

namespace SurveySystem.Controllers
{
    [Route("api/surveyuser/{userId}/answers")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly IRepositoryManager _repository; 
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public AnswersController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllAnswersForUser(int userId)
        {
            var surveyUser = _repository.SurveyUsers.GetSingleSurveyUser(userId, trackChanges: false);

            var answersFromDb = _repository.Answers.GetAllAnswers(userId, trackChanges: false);

            var answersDto = _mapper.Map<IEnumerable<AnswersDto>>(answersFromDb);

            return Ok(answersDto);
        }

        [HttpGet("{Id}", Name = "GetAnswerForUser")]
        public IActionResult GetAnswerForUser(int Id, int answersid)
        {
            var surveyUser = _repository.SurveyUsers.GetSingleSurveyUser(Id, trackChanges: false);
            if (surveyUser == null)
            {
                _logger.LogInfo($"User with id: {Id} not exists.");
                return NotFound();
            }

            var answerDb = _repository.Answers.GetAnswer(Id, answersid, trackChanges: false);
            if (answerDb == null)
            {
                _logger.LogInfo($"Answer with id: {answersid} not exists.");
                return NotFound();
            }

            var answer = _mapper.Map<AnswersDto>(answerDb);

            return Ok(answer);
        }

        [HttpPost]
        public IActionResult CreateAnswerForSurveyUser(int userId, [FromBody] AnswersForCreationDto answers)
        {
            if (answers == null)
            {
                _logger.LogError("Object sent from client is null.");
                return BadRequest("Object sent from client is null.");
            }

            var surveyUser = _repository.SurveyUsers.GetSingleSurveyUser(userId, trackChanges: false);
            if (surveyUser == null)
            {
                _logger.LogInfo($"Survey user with id: {userId} not exists.");
                return NotFound();
            }

            var answerEntity = _mapper.Map<Answers>(answers);

            _repository.Answers.CreateAnswerForSurveyUser(userId, answerEntity);
            _repository.Save();

            var answerToReturn = _mapper.Map<AnswersDto>(answerEntity);

            return CreatedAtRoute("GetAnswerForUser", new { userId, id = answerToReturn.Id, answerEntity.OptionId },
                answerToReturn);
        }
    }
}
