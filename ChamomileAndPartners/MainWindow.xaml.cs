using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CP.Controller;
using CP.Controller.Base;
using CP.Types.Interfaces;
using CP.Types.Implementation;
using System.Data;

namespace ChamomileAndPartners
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Controllers
        CompanyViewController companyViewController = new CompanyViewController();
        CompanyEditController companyEditController = new CompanyEditController();
        UsersViewController userViewController = new UsersViewController();
        UserEditController userEditController = new UserEditController();
        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }


        #region Private methods
        public void FillEditTab()
        {
            try
            {
                FillContractLists();
                FillCompanyListEdit();
                FillUserListEdit();

            }
            catch (Exception ex) { DisplayInfo(ex.Message, ex); }

        }
        private void FillCompanyListEdit()
        {
            try
            {

                List<ICompany> companies = companyViewController.GetList();
                if (companies != null)
                {
                    lbCompanies.ItemsSource = companies;
                    lbCompanies.DisplayMemberPath = "Name";
                    lbCompanies.SelectedIndex = 0;

                    cbUserCompanyEdit.ItemsSource = companies;
                    cbUserCompanyEdit.DisplayMemberPath = "Name";
                    cbUserCompanyEdit.SelectedIndex = 0;

                    cbCompanyUserAdd.ItemsSource = companies;
                    cbCompanyUserAdd.DisplayMemberPath = "Name";
                    cbCompanyUserAdd.SelectedIndex = 0;

                    FillCompanyDataEdit();

                }
            }
            catch (Exception ex)
            {
                DisplayInfo(ex.Message, ex);
            }
        }
        private void FillCompanyDataEdit()
        {
            try
            {
                ICompany company;

                if (lbCompanies.SelectedValue != null)
                {
                    company = (ICompany)lbCompanies.SelectedValue;
                }
                else
                {
                    company = (ICompany)lbCompanies.Items[0];
                }

                tbCompanyNameEdit.Text = company.Name;
                tbCompanyCreateDateEdit.Text = company.CreatedDate.ToString();
                tbCompanyModifyDateEdit.Text = company.LastModifyDate.ToString();
                //cbCompanyContractEdit.

                foreach (IContractStatus item in cbCompanyContractEdit.Items)
                {
                    int selId = ((IContractStatus)item).Id;
                    if (company.ContractStatusId == selId)
                    {
                        cbCompanyContractEdit.SelectedItem = item;
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayInfo(ex.Message, ex);
            }
        }
        private void FillContractLists()
        {
            try
            {

                List<IContractStatus> contracts = companyViewController.GetContractList();
                if (contracts != null)
                {

                    cbCompanyContractEdit.ItemsSource = contracts;
                    cbCompanyContractEdit.DisplayMemberPath = "ContractStatusName";
                    cbCompanyContractEdit.SelectedIndex = 0;

                    cbContractCompanyAdd.ItemsSource = contracts;
                    cbContractCompanyAdd.DisplayMemberPath = "ContractStatusName";
                    cbContractCompanyAdd.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                DisplayInfo(ex.Message, ex);
            }
        }
        private void FillUserListEdit()
        {
            try
            {
                UsersViewController userController = new UsersViewController();
                List<IUser> users = (userController as UsersViewController).GetList();
                if (users != null)
                {
                    lbUsers.ItemsSource = users;
                    lbUsers.DisplayMemberPath = "Name";
                    lbUsers.SelectedIndex = 0;

                    FillUserDataEdit();
                    userController.Dispose();
                }
            }
            catch (Exception ex)
            {
                DisplayInfo(ex.Message, ex);
            }
        }
        private void FillUserDataEdit()
        {
            try
            {
                IUser user;

                if (lbUsers.SelectedValue != null)
                {
                    user = (IUser)lbUsers.SelectedValue;
                }
                else
                {
                    user = (IUser)lbUsers.Items[0];
                }

                tbUsersNameEdit.Text = user.Name;
                tbUserLoginEdit.Text = user.Login;
                tbUsersCreateDateEdit.Text = user.CreatedDate.ToString();
                tbUsersModifyDateEdit.Text = user.LastModifyDate.ToString();

                foreach (ICompany item in cbUserCompanyEdit.Items)
                {
                    int selId = item.Id;
                    if (user.CompanyId == selId)
                    {
                        cbUserCompanyEdit.SelectedItem = item;
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayInfo(ex.Message, ex);
            }
        }
        private void FillViewTab()
        {
            FillCompaniesListView();
            FillUsersListView();
        }
        private void FillCompaniesListView()
        {
            try
            {


                List<ICompany> companies = companyViewController.GetList();
                if (companies != null)
                {
                    lbCompaniesView.ItemsSource = companies;
                    lbCompaniesView.DisplayMemberPath = "Name";
                    lbCompaniesView.SelectedIndex = 0;

                    FillCompaniesDataView();
                }
            }
            catch (Exception ex)
            {
                DisplayInfo(ex.Message, ex);
            }
        }
        private void FillCompaniesDataView()
        {
            try
            {
                ICompany company = (ICompany)lbCompaniesView.SelectedItem;
                if (company != null)
                {
                    tbCompanyNameView.Text = company.Name;
                    cbCompanyContractView.Text = company.ContractStatus.ContractStatusName;
                    tbCompanyCreateDateView.Text = company.CreatedDate.ToString();
                    tbCompanyModifyDateView.Text = company.LastModifyDate.ToString();
                }
            }
            catch (Exception ex)
            {
                DisplayInfo(ex.Message, ex);
            }

        }
        private void FillUsersListView()
        {
            try
            {
                if (lbCompaniesView.SelectedItem != null)
                    lbUsersView.ItemsSource = userViewController.GetListByCompanyId(((ICompany)lbCompaniesView.SelectedItem).Id);
                else
                    lbUsersView.ItemsSource = userViewController.GetListByCompanyId(((ICompany)lbCompaniesView.Items[0]).Id);

                lbUsersView.DisplayMemberPath = "Name";
                lbUsersView.SelectedIndex = 0;
                FillUsersDataView();
            }
            catch (Exception ex)
            {
                DisplayInfo(ex.Message, ex);
            }
        }
        private void FillUsersDataView()
        {
            try
            {
                if (lbUsersView.HasItems && lbUsersView.SelectedItem != null)
                {
                    IUser user = (IUser)lbUsersView.SelectedItem;
                    if (user != null)
                    {
                        tbUsersNameView.Text = user.Name;
                        tbUserLoginView.Text = user.Login;
                        cbUserCompanyView.Text = user.CompanyItem.Name;
                        tbUsersCreateDateView.Text = user.CreatedDate.ToString();
                        tbUsersModifyDateView.Text = user.LastModifyDate.ToString();
                    }
                }
                else
                {
                    tbUsersNameView.Text = String.Empty;
                    tbUserLoginView.Text = String.Empty;
                    cbUserCompanyView.Text = String.Empty;
                    tbUsersCreateDateView.Text = String.Empty;
                    tbUsersModifyDateView.Text = String.Empty;
                }
            }
            catch (Exception ex)
            {
                DisplayInfo(ex.Message, ex);
            }
        }
        private void DisplayInfo(string text, Exception exception)
        {
            lblMessage.Content = text;
        }
        private void ShowAlert(string header, string message)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show(message, header, System.Windows.MessageBoxButton.OK);
        }

        #endregion

        #region Events
        private void btnSaveEditUsers_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(tbUserLoginEdit.Text) && !String.IsNullOrWhiteSpace(tbUsersNameEdit.Text))
                {
                    UsersViewController usersController = new UsersViewController();

                    if ((usersController as UsersViewController).GetItemByLoin(tbUserLoginEdit.Text.Trim()) == null || ((IUser)lbUsers.SelectedValue).Login.Trim() == tbUserLoginEdit.Text.Trim())
                    {
                        User item = new User();
                        item.Id = ((IUser)lbUsers.SelectedItem).Id;
                        item.Name = tbUsersNameEdit.Text.Trim();
                        item.Login = tbUserLoginEdit.Text.Trim();
                        item.CompanyId = ((ICompany)cbUserCompanyEdit.SelectedValue).Id;
                        userEditController.Save(item);
                        FillUserListEdit();
                        ShowAlert("Сохранено!", "Пользователь успешно изменен!");
                    }
                    else
                    {
                        ShowAlert("Внимание!", "Пользователь с таким именем уже существует!");
                    }
                    usersController.Dispose();
                }
                else
                {
                    ShowAlert("Внимание!", "Имя и логин пользователя не могут быть пустыми!");
                    tbUsersNameEdit.Focus();
                }
            }
            catch (Exception ex)
            {
                DisplayInfo(ex.Message, ex);
            }
        }
        private void btnSaveEditCompany_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(tbCompanyNameEdit.Text))
                {


                    if ((companyViewController).GetItemByName(tbCompanyNameEdit.Text.Trim()) == null || ((ICompany)lbCompanies.SelectedValue).Name.Trim() == tbCompanyNameEdit.Text.Trim())
                    {

                        Company item = new Company();
                        item.Id = ((ICompany)lbCompanies.SelectedValue).Id;
                        item.Name = tbCompanyNameEdit.Text;
                        item.ContractStatusId = ((IContractStatus)cbCompanyContractEdit.SelectedValue).Id;
                        companyEditController.Save(item);
                        FillCompanyListEdit();
                        ShowAlert("Сохранено!", "Компания успешно изменена!");

                    }
                    else
                    {
                        ShowAlert("Внимание!", "Компания с таким именем уже существует!");
                        tbNameCompanyAdd.Focus();
                    }
                }
                else
                {
                    ShowAlert("Внимание!", "Имя комании не может быть пустым!");
                    tbNameCompanyAdd.Focus();
                }
            }
            catch (Exception ex)
            {
                DisplayInfo(ex.Message, ex);
            }
        }
        private void btnCompanyAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(tbNameCompanyAdd.Text))
                {


                    if (companyViewController.GetItemByName(tbNameCompanyAdd.Text.Trim()) == null)
                    {



                        Company item = new Company();
                        item.Name = tbNameCompanyAdd.Text.Trim();
                        item.ContractStatusId = ((IContractStatus)cbContractCompanyAdd.SelectedValue).Id;
                        companyEditController.Save(item);
                        FillCompanyListEdit();
                        tbNameCompanyAdd.Text = String.Empty;
                        cbContractCompanyAdd.SelectedItem = cbContractCompanyAdd.Items[0];
                        ShowAlert("Сохранено!", "Компания успешно добавлена!");

                    }
                    else
                    {
                        ShowAlert("Внимание!", "Компания с таким именем уже существует!");
                        tbNameCompanyAdd.Focus();
                    }
                }
                else
                {
                    ShowAlert("Внимание!", "Имя комании не может быть пустым!");
                    tbNameCompanyAdd.Focus();
                }
            }
            catch (Exception ex)
            {
                DisplayInfo(ex.Message, ex);
            }
        }
        private void lbCompanies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbCompanies.SelectedIndex != -1)
            {
                FillCompanyDataEdit();
            }
        }
        private void btnDeleteEditCompany_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Вы уверены что хотите удалить компанию?", "Внимание!", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    if (lbCompanies.SelectedItem != null)
                    {
                        int delId = ((ICompany)lbCompanies.SelectedItem).Id;
                        if (companyEditController.Delete(delId))
                        {
                            ShowAlert("Удалено!", "Компания успешно удалена!");
                            FillCompanyListEdit();
                        }
                        else
                        {

                            ShowAlert("Внимание!", "Компания не была удалена!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayInfo(ex.Message, ex);
            }
        }
        private void btnUserAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(tbLoginUserAdd.Text) && !String.IsNullOrWhiteSpace(tbNameUserAdd.Text) && !String.IsNullOrWhiteSpace(pwPassUserAdd.Password) && !String.IsNullOrWhiteSpace(pwPassConfirmUserAdd.Password))
                {
                    if (pwPassUserAdd.Password.Trim().Equals(pwPassConfirmUserAdd.Password.Trim()))
                    {
                        UsersViewController usersController = new UsersViewController();

                        if ((usersController as UsersViewController).GetItemByLoin(tbLoginUserAdd.Text.Trim()) == null)
                        {

                            User item = new User();
                            item.Name = tbNameUserAdd.Text.Trim();
                            item.Login = tbLoginUserAdd.Text.Trim();
                            item.CompanyId = ((ICompany)cbCompanyUserAdd.SelectedValue).Id;
                            item.Password = pwPassUserAdd.Password;
                            userEditController.Save(item);
                            FillUserListEdit();
                            tbNameUserAdd.Text = String.Empty;
                            tbLoginUserAdd.Text = String.Empty;
                            pwPassUserAdd.Password = String.Empty;
                            pwPassConfirmUserAdd.Password = String.Empty;
                            cbCompanyUserAdd.SelectedItem = cbUserCompanyEdit.Items[0];
                            ShowAlert("Сохранено!", "Пользователь успешно добавлен!");
                        }
                        else
                        {
                            ShowAlert("Внимание!", "Пользователь с таким логином уже существует!");
                            tbLoginUserAdd.Focus();
                        }
                    }
                    else
                    {
                        ShowAlert("Внимание!", "Пароли не совпадают!");
                        pwPassUserAdd.Focus();
                    }
                }
                else
                {
                    ShowAlert("Внимание!", "Имя и логин пользователя не могут быть пустыми!");
                    tbNameUserAdd.Focus();
                }
            }
            catch (Exception ex)
            {
                DisplayInfo(ex.Message, ex);
            }
        }
        private void btnEditUserDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Вы уверены что хотите удалить пользователя?", "Внимание!", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    if (lbUsers.SelectedItem != null)
                    {
                        int delId = ((IUser)lbUsers.SelectedItem).Id;
                        if (userEditController.Delete(delId))
                        {
                            ShowAlert("Удалено!", "Пользователь успешно удален!");
                            FillUserListEdit();
                        }
                        else
                        {
                            ShowAlert("Внимание!", "Пользователь не был удален!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayInfo(ex.Message, ex);
            }
        }
        private void lbUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbUsers.SelectedIndex != -1)
            {
                FillUserDataEdit();
            }
        }
        private void lbCompaniesView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbCompaniesView.SelectedIndex != -1)
            {
                FillCompaniesDataView();
                FillUsersListView();
            }
        }
        private void lbUsersView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbUsersView.SelectedIndex != -1)
            {
                FillUsersDataView();
            }
        }
        private void tabControl_Loaded(object sender, RoutedEventArgs e)
        {
            FillViewTab();
            // FillEditTab();
        }
        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var t = e.Source.GetType();
            if (e.Source is TabControl)
            {
                TabControl tc = (TabControl)sender;
                if (tc != null && (TabItem)tc.SelectedItem != null)
                {
                    switch (((TabItem)tc.SelectedItem).Header.ToString().Trim())
                    {
                        case "Просмотр": FillViewTab(); break;
                        case "Редактирование": FillEditTab(); break;
                    }
                }

            }
        }

        #endregion
    }
}
