using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using midTerm.Data.DataTransferObjects;

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

        [HttpGet("{Id}")]
        public IActionResult GetAnswerForUser(int userId, int id)
        {
            var surveyUser = _repository.SurveyUsers.GetSingleSurveyUser(userId, trackChanges: false);
            if (surveyUser == null)
            {
                _logger.LogInfo($"User with id: {userId} not exists.");
                return NotFound();
            }

            var answerDb = _repository.Answers.GetAnswer(userId, id, trackChanges: false);
            if (answerDb == null)
            {
                _logger.LogInfo($"Answer with id: {id} not exists.");
                return NotFound();
            }

            var answer = _mapper.Map<AnswersDto>(answerDb);

            return Ok(answer);
        }
    }
}
