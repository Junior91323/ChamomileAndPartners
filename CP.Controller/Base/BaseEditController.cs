using CP.Provider.Base;
using CP.Types.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Controller.Base
{
    public class BaseEditController<T> : BaseController<T> where T : class, IBT
    {
        #region Constructors

        public BaseEditController()
            : base()
        {
        }

        #endregion

        #region Public methodts
        public virtual bool Save(T item)
        {
            try
            {
                return (DataProvider as BaseItemProvider<T>).Save(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual bool Delete(int itemID)
        {
            try
            {
                return (DataProvider as BaseItemProvider<T>).Delete(itemID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
