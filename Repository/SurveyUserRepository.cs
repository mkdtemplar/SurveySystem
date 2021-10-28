using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Microsoft.EntityFrameworkCore;
using midTerm.Data;
using midTerm.Data.Entities;

namespace Repository
{
    public class SurveyUserRepository : RepositoryBase<SurveyUser>, ISurveyUserRepository
    {
        public SurveyUserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<SurveyUser> GetAllSurveyUsers(bool trackChanges) =>
            FindAll(trackChanges).Include(a => a.AnswersCollection).ToList();

        public SurveyUser GetSingleSurveyUser(int id, bool trackChanges) =>
            FindByCondition(s => s.Id.Equals(id), trackChanges).Include(a => a.AnswersCollection).SingleOrDefault();

        public void CreateSurveyUser(SurveyUser surveyUser) => Create(surveyUser);
    }
}
