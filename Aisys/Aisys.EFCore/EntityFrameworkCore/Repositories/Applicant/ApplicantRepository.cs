using Microsoft.EntityFrameworkCore;
using Aisys.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aisys.EntityFrameworkCore
{
    public class ApplicantRepository : GenericRepository<Applicant>, IApplicantRepository
    {
        public ApplicantRepository(AisysDbContext dbContext)
        : base(dbContext)
        {

        }

        public async Task<Applicant> GetApplicants()
        {
            return await GetAll()
                .OrderByDescending(c => c.Id)
                .FirstOrDefaultAsync();
        }
    }
}
