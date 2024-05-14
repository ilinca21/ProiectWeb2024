using System.Collections.Generic;
using Solution.Domain.Entities.Responce;
using Solution.Domain.Entities.Case;

namespace Solution.BusinessLogic.Interfaces
{
    public interface ICase
    {
        CaseResp AddCaseAction(NewCaseData data);
        CaseDbTable GetById(int caseId);
        IEnumerable<CaseMinimal> GetCasesByKey(string key);
        IEnumerable<CaseDbTable> GetAll();
        IEnumerable<CaseMinimal> GetAllUrgentCases();
        IEnumerable<CaseMinimal> GetAllFinishedCases();
        CaseResp EditCaseAction(CaseEditData existingCase);
        void Delete(int caseId);
        void Save();
    }
}
