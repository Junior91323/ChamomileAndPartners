using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP.Data;
using CP.Types;
using CP.Provider.Base;
using CP.Types.Interfaces;
using CP.Types.Implementation;

namespace CP.Provider
{
    public class UsersProvider : BaseItemListProvider<IUser>
    {
        #region Constructors

        public UsersProvider()
            : base()
        {
        }

        #endregion

        #region Public methods
        public IUser GetItemByLogin(string login)
        {
            try
            {
                return DBItem.Users.Where(x => x.Login == login).Select(x => new CP.Types.Implementation.User()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Login = x.Login,
                    CreatedDate = x.CreateDate,
                    LastModifyDate = x.LastModifyDate,
                    Password = x.Password,
                    CompanyId = x.CompanyId,
                    CompanyItem = (from company in DBItem.Companies where company.Id == x.CompanyId select new Company() { Id = company.Id, CreatedDate = company.CreateDate, ContractStatusId = company.ContractStatusId, LastModifyDate = company.LastModifyDate, Name = company.Name  }).FirstOrDefault<ICompany>()
                }).FirstOrDefault();
            }
            catch { throw new Exception("Error in work with data base!"); }
        }

        public override IUser GetItemByID(int itemID)
        {
            try
            {
                return DBItem.Users.Where(x => x.Id == itemID).Select(x => new User()
                {
                    Id = x.Id,
                    Name = x.Name,
                    CompanyId = x.CompanyId,
                    CompanyItem = (from company in DBItem.Companies where company.Id == x.CompanyId select new Company() { Id = company.Id, Name = company.Name, CreatedDate = company.CreateDate, ContractStatusId = company.ContractStatusId }).FirstOrDefault(),
                    CreatedDate = x.CreateDate,
                    LastModifyDate = x.LastModifyDate,
                    Login = x.Login,
                    Password = x.Password
                }).FirstOrDefault();
            }
            catch { throw new Exception("Error in work with data base!"); }
        }
        public override List<IUser> GetList()
        {
            try { 
            itemsList = (from item in DBItem.Users
                         select new User()
                         {
                             Id = item.Id,
                             Name = item.Name,
                             CompanyId = item.CompanyId,
                             CompanyItem = (from company in DBItem.Companies where company.Id == item.CompanyId select new Company() { Id = company.Id, Name = company.Name, CreatedDate = company.CreateDate, ContractStatusId = company.ContractStatusId }).FirstOrDefault(),
                             CreatedDate = item.CreateDate,
                             LastModifyDate = item.LastModifyDate,
                             Login = item.Login,
                             Password = item.Password

                         }).OrderBy(x => x.Name).ToList<IUser>();
            return itemsList;
            }
            catch { throw new Exception("Error in work with data base!"); }
        }
        public List<IUser> GetListByCompanyId(int companyId)
        {
            try
            {
                itemsList = (from item in DBItem.Users where item.CompanyId == companyId
                             select new User()
                             {
                                 Id = item.Id,
                                 Name = item.Name,
                                 CompanyId = item.CompanyId,
                                 CompanyItem = (from company in DBItem.Companies where company.Id == item.CompanyId select new Company() { Id = company.Id, Name = company.Name, CreatedDate = company.CreateDate, ContractStatusId = company.ContractStatusId }).FirstOrDefault(),
                                 CreatedDate = item.CreateDate,
                                 LastModifyDate = item.LastModifyDate,
                                 Login = item.Login,
                                 Password = item.Password

                             }).OrderBy(x => x.Name).ToList<IUser>();
                return itemsList;
            }
            catch { throw new Exception("Error in work with data base!"); }
        }
        public override List<IUser> GetList(string sortExpression, int startRows, int maxRows)
        {
            try { 
            itemsList = (from item in DBItem.Users
                         select new User()
                         {
                             Id = item.Id,
                             Name = item.Name,
                             CompanyId = item.CompanyId,
                             CompanyItem = (from company in DBItem.Companies where company.Id == item.CompanyId select new Company() { Id = company.Id, Name = company.Name, CreatedDate = company.CreateDate, ContractStatusId = company.ContractStatusId }).FirstOrDefault(),
                             CreatedDate = item.CreateDate,
                             LastModifyDate = item.LastModifyDate,
                             Login = item.Login,
                             Password = item.Password

                         }).OrderBy(x => x.Name).Skip(startRows).Take(maxRows).ToList<IUser>();
            return itemsList;
            }
            catch { throw new Exception("Error in work with data base!"); }
        }
        public override bool Save(IUser item)
        {
            try
            {
                CP.Data.Users savingItem = null;
                if (item != null)
                {
                    savingItem = DBItem.Users.Where(x => x.Id.Equals(item.Id)).FirstOrDefault();
                    if (savingItem == null)
                    {
                        savingItem = new CP.Data.Users();
                        savingItem.CreateDate = DateTime.Now;
                        savingItem.Name = item.Name;
                        savingItem.Login = item.Login;
                        savingItem.Password = item.Password;
                        savingItem.CompanyId = item.CompanyId;
                        savingItem.LastModifyDate = DateTime.Now;
                        DBItem.Users.Add(savingItem);
                    }
                    else
                    {
                        savingItem.Name = item.Name;
                        savingItem.Login = item.Login;
                        //savingItem.Password = item.Password;
                        savingItem.CompanyId = item.CompanyId;
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
                CP.Data.Users item = DBItem.Users.Where(x => x.Id.Equals(itemID)).FirstOrDefault();
                if (item != null)
                {
                    DBItem.Users.Remove(item);
                    DBItem.SaveChanges();
                    return true;
                }
                return false;
            }
            catch { throw new Exception("Error in work with data base!"); }
        }
        #endregion
        //public List<T> EntitiesList()
        //{
        // dbItem.   Activator.CreateInstance(typeof(T));
        //}
    }
}
