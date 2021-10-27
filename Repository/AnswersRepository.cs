using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using midTerm.Data;
using midTerm.Data.Entities;

namespace Repository
{
    public class AnswersRepository : RepositoryBase<Answers>, IAnswersRepository
    {
        public AnswersRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Answers> GetAllAnswers(int userId, bool trackChanges) =>
            FindByCondition(s => s.UserId.Equals(userId), trackChanges);
    }
}
