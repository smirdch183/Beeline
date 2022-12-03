using Beeline.FolderClass;
using Beeline.FolderData;
using Microsoft.Win32;
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
using Beeline.FolderWindow;

namespace Beeline.FolderPage.FolderAdmin
{
    /// <summary>
    /// Логика взаимодействия для AdminAddSotrPage.xaml
    /// </summary>
    public partial class AdminAddSotrPage : Page
    {
        Sotr sotr = new Sotr();
        Phone phone=new Phone();
        public AdminAddSotrPage()
        {
            InitializeComponent();
            //CbPhone.ItemsSource = DBEntities.GetContext().Phone
            //        .Where(c => c.StatusPhone.NameStatusPhone.StartsWith("Не занят")
            //        || c.StatusPhone.NameStatusPhone.StartsWith("Не занят")).ToList();
            CbRole.ItemsSource = DBEntities.GetContext().Role.ToList();
        }
        //string selectedFileName = "";
        //private void AddPhoto()
        //{
        //    try
        //    {
        //        OpenFileDialog op = new OpenFileDialog();
        //        op.InitialDirectory = "";
        //        op.Filter = "All supported graphics|*.jpg;*.jpeg;" +
        //            "*.png;|JPEG(*.jpg;*.jpeg;)|*.jpg;*.jpeg|" +
        //            "Portable Network Graphic (*.png)|*.png";

        //        if (op.ShowDialog() == true)
        //        {
        //            selectedFileName = op.FileName;
        //            sotr.Image = LoadAndReadImageClass
        //                .ConvertImageToByteArray(selectedFileName);
        //            PhotoIm.Source = LoadAndReadImageClass
        //                .ConvertByteArrayImage(sotr.Image);
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        //private void LoadPhotoBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    AddPhoto();
        //}
        
        //private void BnSave_Click(object sender, RoutedEventArgs e)
        //{
        //    if (TbLastName.Text != "" & TbFirstName.Text != "" &
        //        CbPhone.Text != "" & DpBirthday.Text != "" & selectedFileName != null)
        //    {
        //        //try
        //        //{
        //            var sotrAdd = new Sotr()
        //            {
        //                LastName = TbLastName.Text,
        //                FirstName = TbFirstName.Text,
        //                MidleName = TbMidleName.Text,
        //                Phone = CbPhone.Text,
        //                Birthday = DateTime.Parse(DpBirthday.Text),
        //                Email = TbEmail.Text,
        //                SeriesAndNumber = TbSeriesAndNumber.Text,
        //                DateOfIssue = DateTime.Parse(DpDateOfIssue.Text),
        //                Image = LoadAndReadImageClass.ConvertImageToByteArray(selectedFileName),
        //                IdUser = user.IdUser
        //            };
        //                DBEntities.GetContext().Sotr.Add(sotrAdd);
        //            DBEntities.GetContext().SaveChanges();
        //            phone = DBEntities.GetContext().Phone.FirstOrDefault(p => p.Number == CbPhone.Text);
        //                phone.IdStatusPhone = 1;
        //            //не работает
        //                DBEntities.GetContext().SaveChanges();
        //            ClassMB.MBinformation("Успешно");
        //            this.NavigationService.Navigate(new AdminAddSotrPage());
        //    //}
        //    //    catch (Exception ex)
        //    //{
        //    //    ClassMB.MBerror(ex);
        //    //}
        //}
        //    else
        //    {
        //        ClassMB.MBerror("Заполните все поля!");
        //    }
        //}
        User user = new User();
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (TbLogin.Text != "" & TbPassword.Password != "" & TbRepitPassword.Password != "" & CbRole.Text != "")
            {
                if (TbPassword.Password == TbRepitPassword.Password)
                {
                    try
                    {
                        var userAdd = new User()
                        {
                            Login = TbLogin.Text,
                            Password = TbPassword.Password,
                            IdRole = Int32.Parse(CbRole.SelectedValue.ToString())
                        };
                        DBEntities.GetContext().User.Add(userAdd);
                        DBEntities.GetContext().SaveChanges();
                        user.IdUser = userAdd.IdUser;
                        ClassGlobal.UserId = user.IdUser;
                        ClassGlobal.Window = 2;
                        //ClassMB.MBinformation($"{user.IdUser}");
                        LoadPage();
                        //AddUser.Visibility = Visibility.Hidden;
                        //AddSotr.Visibility = Visibility.Visible;
                        //MainFrameAddWindow mainFrameAddWindow = new MainFrameAddWindow();
                        //mainFrameAddWindow.Show();
                        //Application.Current.MainWindow.Close();
                        NavigationService.Navigate(new AdminAddSotrProdolgPage());
                    }
                    catch (Exception ex)
                    {
                        ClassMB.MBerror(ex);
                    }
                }
                else
                {
                    ClassMB.MBerror("Пароли не совпадают");
                }
            }
            else
            {
                ClassMB.MBerror("Заполните все поля!");
            }
        }
        MainFrameWindow mainFrameWindow = new MainFrameWindow();
        private void LoadPage()
        {

            mainFrameWindow.SpButton.Visibility = Visibility.Collapsed;
        }
    }
}
