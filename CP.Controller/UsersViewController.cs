using CP.Types.Interfaces;
using CP.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP.Controller.Base;

namespace CP.Controller
{
    public class UsersViewController : BaseViewController<IUser>
    {
        #region Constructors

        public UsersViewController()
            : base()
        {
            DataProvider = new UsersProvider();
        }

        #endregion
        #region Public methods
        public IUser GetItemByLoin(string login)
        {
            return (DataProvider as UsersProvider).GetItemByLogin(login);
        }
        public List<IUser> GetListByCompanyId(int companyId)
        {
            return (DataProvider as UsersProvider).GetListByCompanyId(companyId);
        }
        #endregion

    }
}
