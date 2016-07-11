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
    public class CompanyViewController : BaseViewController<ICompany>
    {
        #region Constructors

        public CompanyViewController()
            : base()
        {
            DataProvider = new CompanyProvider();
        }

        #endregion

        public ICompany GetItemByName(string name)
        {
            return (DataProvider as CompanyProvider).GetItemByName(name);
        }
        public List<IContractStatus> GetContractList()
        {
            return (DataProvider as CompanyProvider).GetContractsList();
        }
    }
}
