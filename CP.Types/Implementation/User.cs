using CP.Types.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Types.Implementation
{
    public class User : IUser
    {
        public ICompany CompanyItem { get; set; }

        public int CompanyId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int Id { get; set; }

        public DateTime? LastModifyDate { get; set; }

        public string Login { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }
    }
}
