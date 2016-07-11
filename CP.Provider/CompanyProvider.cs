using CP.Provider.Base;
using CP.Types.Interfaces;
using CP.Types.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Provider
{
    public class CompanyProvider : BaseItemListProvider<ICompany>
    {
        #region Constructors

        public CompanyProvider()
            : base()
        {
        }

        #endregion

        #region Public methods
        public ICompany GetItemByName(string name)
        {
            try
            {
                return DBItem.Companies.Where(x => x.Name == name).Select(x=> new Company() {
                    Id = x.Id,
                    Name = x.Name,
                    ContractStatusId = x.ContractStatusId,
                    CreatedDate = x.CreateDate,
                    LastModifyDate = x.LastModifyDate,
                    Users = (from users in DBItem.Users where users.CompanyId == x.Id select new User() { Id = users.Id, CompanyId = users.CompanyId, CreatedDate = users.CreateDate, Login = users.Login, Name = users.Name, Password = users.Password }).ToList<IUser>()
                }).FirstOrDefault();
            }
            catch { throw new Exception("Error in work with data base!"); }
        }
        public override ICompany GetItemByID(int itemID)
        {
            try { 
            return DBItem.Companies.Where(x => x.Id == itemID).Select(x => new Company()
            {
                Id = x.Id,
                Name = x.Name,
                CreatedDate = x.CreateDate,
                LastModifyDate = x.LastModifyDate,
                ContractStatusId = x.ContractStatusId,
                Users = (from users in DBItem.Users where users.CompanyId == x.Id select new User() { Id = users.Id, CompanyId = users.CompanyId, CreatedDate = users.CreateDate, Login = users.Login, Name = users.Name, Password = users.Password }).ToList<IUser>()
            }).FirstOrDefault();
            }
            catch { throw new Exception("Error in work with data base!"); }
        }
        public override List<ICompany> GetList()
        {
            try {
                List<ICompany> res = (from item in DBItem.Companies
                         select new Company()
                         {
                             Id = item.Id,
                             Name = item.Name,
                             CreatedDate = item.CreateDate,
                             LastModifyDate = item.LastModifyDate,
                             ContractStatusId = item.ContractStatusId,
                             ContractStatus = (from contract in DBItem.ContractStatus where contract.Id == item.ContractStatusId select new ContractStatus() { Id = contract.Id, ContractStatusName = contract.ContractStatus1 }).FirstOrDefault(),
                             Users = (from users in DBItem.Users where users.CompanyId == item.Id select new User() { Id = users.Id, CompanyId = users.CompanyId, CreatedDate = users.CreateDate, Login = users.Login, Name = users.Name, Password = users.Password }).ToList<IUser>()
                         }).OrderBy(x => x.Name).ToList<ICompany>();
            return res;
            }
            catch { throw new Exception("Error in work with data base!"); }
        }

        public override List<ICompany> GetList(string sortExpression, int startRows, int maxRows)
        {
            try { 
            itemsList = (from item in DBItem.Companies
                         select new Company()
                         {
                             Id = item.Id,
                             Name = item.Name,
                             CreatedDate = item.CreateDate,
                             LastModifyDate = item.LastModifyDate,
                             ContractStatusId = item.ContractStatusId,
                             Users = (from users in DBItem.Users where users.CompanyId == item.Id select new User() { Id = users.Id, CompanyId = users.CompanyId, CreatedDate = users.CreateDate, Login = users.Login, Name = users.Name, Password = users.Password }).ToList<IUser>()
                         }).OrderBy(x => x.Name).Skip(startRows).Take(maxRows).ToList<ICompany>();
            return itemsList;
            }
            catch { throw new Exception("Error in work with data base!"); }
        }
        public override bool Save(ICompany item)
        {
            try
            {
                CP.Data.Companies savingItem = null;
                if (item != null)
                {
                    savingItem = DBItem.Companies.Where(x => x.Id == item.Id).FirstOrDefault();
                    if (savingItem == null)
                    {
                        savingItem = new CP.Data.Companies();
                        savingItem.CreateDate = DateTime.Now;
                        savingItem.Name = item.Name;
                        savingItem.ContractStatusId = item.ContractStatusId;
                        savingItem.LastModifyDate = DateTime.Now;
                        DBItem.Companies.Add(savingItem);
                    }
                    else
                    {
                        savingItem.Name = item.Name;
                        savingItem.ContractStatusId = item.ContractStatusId;
                        savingItem.LastModifyDate = DateTime.Now;
                        DBItem.Entry(savingItem).State = System.Data.Entity.EntityState.Modified;
                    }
                    DBItem.SaveChanges();
                }
                return true;
            }
            catch (Exception ex) { throw new Exception("Error in work with data base!"); }

        }
        public override bool Delete(int itemID)
        {
            try
            {
                CP.Data.Companies item = DBItem.Companies.Where(x => x.Id == itemID).FirstOrDefault();
                if (item != null)
                {
                    DBItem.Companies.Remove(item);
                    DBItem.SaveChanges();
                    return true;
                }
                return false;
            }
            catch { throw new Exception("Error in work with data base!"); }
        }
        public List<IContractStatus> GetContractsList()
        {
            try
            {
                return (from items in DBItem.ContractStatus select new CP.Types.Implementation.ContractStatus () {Id = items.Id, ContractStatusName = items.ContractStatus1 }).OrderBy(x=>x.ContractStatusName).ToList<IContractStatus>();
            }
            catch(Exception ex) { throw new Exception("Error in work with data base!"); }
        }
        #endregion
    }
}
