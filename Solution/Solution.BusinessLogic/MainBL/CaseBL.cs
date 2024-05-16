using System.Collections.Generic;
using System.Linq;
using Solution.BusinessLogic.Core;
using Solution.BusinessLogic.DBModel.Seed;
using Solution.BusinessLogic.Interfaces;
using Solution.Domain.Entities.Responce;
using Solution.Domain.Entities.Case;

namespace Solution.BusinessLogic.MainBL
{
    public class CaseBL : AdminApi, ICase
    {
        private readonly CaseContext _context;

        public CaseBL()
        {
            _context = new CaseContext();
        }

        public CaseBL(CaseContext context)
        {
            _context = context;
        }

        public CaseResp AddCaseAction(NewCaseData data)
        {
            return AddCase(data);
        }

        public CaseResp EditCaseAction(CaseEditData existingCase)
        {
            return ReturnEditedCase(existingCase);
        }

        public CaseDbTable GetById(int caseId)
        {
            return _context.Cases.Find(caseId);
        }

        public IEnumerable<CaseMinimal> GetCasesByKey(string key)
        {
            return ReturnCasesByKey(key);
        }

        public IEnumerable<CaseMinimal> GetAll()
        {
            return ReturnCases();
        }

        public IEnumerable<CaseMinimal> GetAllUrgentCases()
        {
            return ReturnUrgentCases();
        }

        public IEnumerable<CaseMinimal> GetAllFinishedCases()
        {
            return ReturnFinishedCases();
        }

        public void Delete(int caseID)
        {
            CaseDbTable model = _context.Cases.Find(caseID);
            if (model != null)
            {
                _context.Cases.Remove(model);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
