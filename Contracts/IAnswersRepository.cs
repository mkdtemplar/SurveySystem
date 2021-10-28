using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using midTerm.Data.Entities;

namespace Contracts
{
    public interface IAnswersRepository
    {
        IEnumerable<Answers> GetAllAnswers(int userId, bool trackChanges);

        Answers GetAnswer(int userId, int id, bool trackChanges);
    }
}
