using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Provider.Base
{
   public class BaseItemListProvider<T> : BaseItemProvider<T>
    {
        #region Fields
        protected List<T> itemsList;
        #endregion
        #region Properties
        public List<T> ItemsList
        {
            get { return itemsList; }
            set { itemsList = value; }
        }
        #endregion
        #region Constrctors
        public BaseItemListProvider()
           : base()
        {
        }
        #endregion
        #region Public methods
        public virtual List<T> GetList()
        {
            throw new NotImplementedException("The method has to be overrided");
        }
        public virtual List<T> GetList(string sortExpression, int startRows, int maxRows)
        {
            throw new NotImplementedException("The method has to be overrided");
        }
        #endregion
    }
}
