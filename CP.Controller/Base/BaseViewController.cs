using CP.Provider.Base;
using CP.Types.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Controller.Base
{
    public class BaseViewController<T> : BaseController<T> where T : class, IBT
    {
        #region Constructors

        public BaseViewController()
            : base()
        {
        }

        #endregion

        #region Public methods
        public virtual T GetItemByID(int itemID)
        {
            return (DataProvider as BaseItemProvider<T>).GetItemByID(itemID);
        }
        public virtual List<T> GetList()
        {
            return (DataProvider as BaseItemListProvider<T>).GetList();
        }
        #endregion
    }
}
