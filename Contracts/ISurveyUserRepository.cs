using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using midTerm.Data.Entities;

namespace Contracts
{
    public interface ISurveyUserRepository
    {
        IEnumerable<SurveyUser> GetAllSurveyUsers(bool trackChanges);

        SurveyUser GetSingleSurveyUser(int id, bool trackChanges);
    }
}
