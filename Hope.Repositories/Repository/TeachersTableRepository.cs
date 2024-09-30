using Hope.DomainEntites.DbEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hope.Repositories.Repository
{
    public class TeachersTableRepository : Repository<TeachersTable> , IRepository.ITeachersTableRepository
    { 
        public TeachersTableRepository() 
        {
        
        }
    }
}
