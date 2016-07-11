using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Provider.Base
{
  public  class BaseItemProvider<T> : BaseProvider<T>
    {
        #region Constructors
        public BaseItemProvider() : base()
        {
        }
        #endregion
        #region Public methods
        public virtual bool Save(T item)
        {
            throw new NotImplementedException("The method has to be overrided");
        }
        public virtual bool Delete(int itemID)
        {
            throw new NotImplementedException("The method has to be overrided");
        }
        public virtual T GetItemByID(int itemID)
        {

            throw new NotImplementedException("The method has to be overrided");
        }
        #endregion
    }
}
