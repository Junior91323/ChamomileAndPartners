using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP.Data;

namespace CP.Provider.Base
{
    public abstract class BaseProvider<T> : IDisposable
    {
        #region Fields
        public ChamomileAndPartnersEntities dbItem;
        #endregion
        #region Properties
        protected ChamomileAndPartnersEntities DBItem
        {
            get
            {
                if (dbItem == null)
                {
                    dbItem = new ChamomileAndPartnersEntities();
                }
                return dbItem;
            }

        }
        #endregion
        public void Dispose()
        {
            dbItem.Dispose();
        }
    }
}
