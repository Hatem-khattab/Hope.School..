using Hope.DomainEntites.DbEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hope.Repositories.Repository
{
    public class SectionTableRepository : Repository<SectionTable> , IRepository.ISectionTableRepository
    {
        public SectionTableRepository() 
        {
        
        }
    }
}
