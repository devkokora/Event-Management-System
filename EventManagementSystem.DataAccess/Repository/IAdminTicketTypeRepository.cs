using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.DataAccess.Repository
{
    public interface IAdminTicketTypeRepository
    {
        Task<int> DeleteAsync(int id);
    }
}
