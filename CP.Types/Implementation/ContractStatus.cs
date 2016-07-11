using CP.Types.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Types.Implementation
{
  public  class ContractStatus : IContractStatus
    {
        public DateTime? CreatedDate { get; set; }

        public int Id { get; set; }

        public DateTime? LastModifyDate { get; set; }

        public string ContractStatusName { get; set; }
    }
}
