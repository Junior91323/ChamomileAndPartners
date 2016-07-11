using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Types.Interfaces
{
    public interface IUser : IBT
    {
        int Id { get; set; }
        string Name { get; set; }
        string Login { get; set; }
        string Password { get; set; }
        int CompanyId { get; set; }
        ICompany CompanyItem { get; set; }
    }
}
