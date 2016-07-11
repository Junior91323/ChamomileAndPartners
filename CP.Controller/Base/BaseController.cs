using CP.Provider.Base;
using CP.Types.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Controller.Base
{
    public class BaseController<T> : IDisposable where T : class, IBT
    {
        #region Fields 
        protected BaseProvider<T> DataProvider;
        #endregion
        #region Constructors
        public BaseController()
        {
        }
        #endregion
        public void Dispose()
        {
            DataProvider.Dispose();
        }
    }
}
