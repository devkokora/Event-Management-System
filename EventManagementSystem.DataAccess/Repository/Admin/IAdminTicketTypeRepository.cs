using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.DataAccess.Repository.Admin
{
    public interface IAdminTicketTypeRepository
    {
        Task<int> DeleteAsync(int id);
        Task<int> DeleteAllAsync(IEnumerable<int> ticketTypeIds);
    }
}
