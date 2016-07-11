using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Types.Interfaces
{
   public interface IContractStatus:IBT
    {
        int Id { get; set; }
        string ContractStatusName { get; set; }
    }
}
