using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using midTerm.Data.DataTransferObjects;
using midTerm.Data.Entities;

namespace SurveySystem
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SurveyUser, SurveyUserDto>();

            CreateMap<Answers, AnswersDto>();

            CreateMap<SurveyUserCreationDto, SurveyUser>();
        }
    }
}
