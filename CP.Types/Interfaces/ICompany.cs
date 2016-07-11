using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Types.Interfaces
{
    public interface ICompany:IBT
    {
        int Id { get; set; }
        string Name { get; set; }
        int ContractStatusId { get; set; }
        IContractStatus ContractStatus { get; set; }
        IEnumerable<IUser> Users { get; set; }
    }
}
