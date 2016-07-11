using CP.Controller.Base;
using CP.Provider;
using CP.Types.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Controller
{
   public class CompanyEditController : BaseEditController<ICompany>
    {
        #region Constructors

        public CompanyEditController()
            : base()
        {
            DataProvider = new CompanyProvider();
        }

        #endregion
    }
}
