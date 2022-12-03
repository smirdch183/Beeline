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
using Beeline.FolderClass;
using Beeline.FolderData;
using Beeline.FolderPage;
using Beeline.FolderWindow;
using Beeline.FolderPage.FolderAdmin;
using Microsoft.Win32;

namespace Beeline.FolderPage.FolderAdmin
{
    /// <summary>
    /// Логика взаимодействия для AdminAddSotrProdolgPage.xaml
    /// </summary>
    public partial class AdminAddSotrProdolgPage : Page
    {
        Sotr sotr = new Sotr();
        Phone phone = new Phone();
        public AdminAddSotrProdolgPage()
        {
            InitializeComponent();
            CbPhone.ItemsSource = DBEntities.GetContext().Phone
                    .Where(c => c.StatusPhone.NameStatusPhone.StartsWith("Не занят")
                    || c.StatusPhone.NameStatusPhone.StartsWith("Не занят")).ToList();
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainFrameWindow))
                {
                    (window as MainFrameWindow).BnBack.Visibility = Visibility.Collapsed;
                    (window as MainFrameWindow).HomeIm.Visibility = Visibility.Collapsed;
                    (window as MainFrameWindow).ClientIm.Visibility = Visibility.Collapsed;
                    (window as MainFrameWindow).SotrIm.Visibility = Visibility.Collapsed;
                    (window as MainFrameWindow).SotrSIm.Visibility = Visibility.Collapsed;
                    (window as MainFrameWindow).DogovorIm.Visibility = Visibility.Collapsed;
                    (window as MainFrameWindow).TarifAddIm.Visibility = Visibility.Collapsed;
                    (window as MainFrameWindow).TarifIm.Visibility = Visibility.Collapsed;
                }
            }
        }
        string selectedFileName = "";
        private void AddPhoto()
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.InitialDirectory = "";
                op.Filter = "All supported graphics|*.jpg;*.jpeg;" +
                    "*.png;|JPEG(*.jpg;*.jpeg;)|*.jpg;*.jpeg|" +
                    "Portable Network Graphic (*.png)|*.png";

                if (op.ShowDialog() == true)
                {
                    selectedFileName = op.FileName;
                    sotr.Image = LoadAndReadImageClass
                        .ConvertImageToByteArray(selectedFileName);
                    PhotoIm.Source = LoadAndReadImageClass
                        .ConvertByteArrayImage(sotr.Image);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void LoadPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            AddPhoto();
        }
        private void BnSave_Click(object sender, RoutedEventArgs e)
        {
            if (TbLastName.Text != "" & TbFirstName.Text != "" &
                CbPhone.Text != "" & DpBirthday.Text != "" & selectedFileName != null)
            {
                try
                {
                    var sotrAdd = new Sotr()
                {
                    LastName = TbLastName.Text,
                    FirstName = TbFirstName.Text,
                    MidleName = TbMidleName.Text,
                    Phone = CbPhone.Text,
                    Birthday = DateTime.Parse(DpBirthday.Text),
                    Email = TbEmail.Text,
                    SeriesAndNumber = TbSeriesAndNumber.Text,
                    DateOfIssue = DateTime.Parse(DpDateOfIssue.Text),
                    Image = LoadAndReadImageClass.ConvertImageToByteArray(selectedFileName),
                    IdUser = ClassGlobal.UserId
                };
                DBEntities.GetContext().Sotr.Add(sotrAdd);
                DBEntities.GetContext().SaveChanges();
                phone = DBEntities.GetContext().Phone.FirstOrDefault(p => p.Number == CbPhone.Text);
                phone.IdStatusPhone = 1;
                //не работает
                DBEntities.GetContext().SaveChanges();
                ClassMB.MBinformation("Успешно");
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainFrameWindow))
                        {
                            (window as MainFrameWindow).HomeIm.Visibility = Visibility.Visible;
                            (window as MainFrameWindow).ClientIm.Visibility = Visibility.Visible;
                            (window as MainFrameWindow).SotrIm.Visibility = Visibility.Visible;
                            (window as MainFrameWindow).SotrSIm.Visibility = Visibility.Visible;
                            (window as MainFrameWindow).DogovorIm.Visibility = Visibility.Visible;
                            (window as MainFrameWindow).TarifAddIm.Visibility = Visibility.Visible;
                            (window as MainFrameWindow).TarifIm.Visibility = Visibility.Visible;
                            (window as MainFrameWindow).BnBack.Visibility = Visibility.Collapsed;
                        }
                    }
                    NavigationService.Navigate(new AdminListPage());

                }
                catch (Exception ex)
                {
                    ClassMB.MBerror(ex);
                }
            }
            else
            {
                ClassMB.MBerror("Заполните все поля!");
            }
        }
    }
}
