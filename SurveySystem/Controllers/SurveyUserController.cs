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
    [Route("api/surveyuser")]
    [ApiController]
    public class SurveyUserController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public SurveyUserController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllSurveyUsers()
        {
            var surveyUsers = _repository.SurveyUsers.GetAllSurveyUsers(trackChanges: false);
            var surveyUsersDto = _mapper.Map<IEnumerable<SurveyUserDto>>(surveyUsers);
            return Ok(surveyUsersDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingleSurveyUser(int id)
        {
            var surveyUser = _repository.SurveyUsers.GetSingleSurveyUser(id, trackChanges: false);

            if (surveyUser == null)
            {
                _logger.LogInfo($"User with id: {id} not exist.");
                return NotFound();
            }

            var surveyUserDto = _mapper.Map<SurveyUserDto>(surveyUser);
            return Ok(surveyUserDto);
        }
    }
}
