using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using midTerm.Data;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private ISurveyUserRepository _surveyUserRepository;
        private IAnswersRepository _answersRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IAnswersRepository Answers
        {
            get
            {
                if (_answersRepository == null)
                {
                    _answersRepository = new AnswersRepository(_repositoryContext);
                }

                return _answersRepository;
            }
        }

        public ISurveyUserRepository SurveyUsers
        {
            get
            {
                if (_surveyUserRepository == null)
                {
                    _surveyUserRepository = new SurveyUserRepository(_repositoryContext);
                }

                return _surveyUserRepository;
            }
        }

        public void Save() => _repositoryContext.SaveChanges();
    }
}
