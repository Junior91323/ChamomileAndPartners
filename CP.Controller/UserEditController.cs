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
   public class UserEditController : BaseEditController<IUser>
    {
        #region Constructors

        public UserEditController()
            : base()
        {
            DataProvider = new UsersProvider();
        }

        #endregion
    }
}
