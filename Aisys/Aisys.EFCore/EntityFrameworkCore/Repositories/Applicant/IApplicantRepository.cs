using Aisys.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aisys.EntityFrameworkCore
{
    public interface IApplicantRepository : IGenericRepository<Applicant>
    {
        Task<Applicant> GetApplicants();
    }
}
