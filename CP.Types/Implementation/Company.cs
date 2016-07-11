using CP.Types.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Types.Implementation
{
    public class Company : ICompany
    {
        public IContractStatus ContractStatus { get; set; }

        public int ContractStatusId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int Id { get; set; }

        public DateTime? LastModifyDate { get; set; }

        public string Name { get; set; }

        public IEnumerable<IUser> Users { get; set; }
    }
}
