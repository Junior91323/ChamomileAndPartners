using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Types.Interfaces
{
   public interface IBT
    {
        DateTime? CreatedDate { get; set; }
        DateTime? LastModifyDate { get; set; }
    }
}
