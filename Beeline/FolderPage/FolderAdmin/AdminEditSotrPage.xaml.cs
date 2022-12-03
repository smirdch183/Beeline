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
using Beeline.FolderData;
using Microsoft.Win32;
using Beeline.FolderClass;

namespace Beeline.FolderPage.FolderAdmin
{
    /// <summary>
    /// Логика взаимодействия для AdminEditSotrPage.xaml
    /// </summary>
    public partial class AdminEditSotrPage : Page
    {
        public AdminEditSotrPage(Sotr sotr)
        {
            InitializeComponent();
            DataContext = sotr;
        }
        string selectedFileName = "";
        Sotr sotr = new Sotr();
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
            if (selectedFileName == null)
            {
                Sotr sotr = DBEntities.GetContext().Sotr.FirstOrDefault(s => s.IdSotr == ClassVariable.IdSotr);
                sotr.LastName = TbLastName.Text;
                sotr.FirstName = TbFirstName.Text;
                sotr.MidleName = TbMidleName.Text;
                sotr.Phone = TbPhone.Text;
                sotr.Email = TbEmail.Text;
                sotr.SeriesAndNumber = TbSeriesAndNumber.Text;
                sotr.DateOfIssue = Convert.ToDateTime(DpDateOfIssue.Text);
                sotr.Birthday = Convert.ToDateTime(DpBirthday.Text);
                sotr.Image = LoadAndReadImageClass.ConvertImageToByteArray(selectedFileName);
                DBEntities.GetContext().SaveChanges();
                ClassMB.MBinformation("Успешно");
                this.NavigationService.Navigate(new AdminListPage());
            }
            else
            {
                Sotr sotr = DBEntities.GetContext().Sotr.FirstOrDefault(s => s.IdSotr == ClassVariable.IdSotr);
                sotr.LastName = TbLastName.Text;
                sotr.FirstName = TbFirstName.Text;
                sotr.MidleName = TbMidleName.Text;
                sotr.Phone = TbPhone.Text;
                sotr.Email = TbEmail.Text;
                sotr.SeriesAndNumber = TbSeriesAndNumber.Text;
                sotr.DateOfIssue = Convert.ToDateTime(DpDateOfIssue.Text);
                sotr.Birthday = Convert.ToDateTime(DpBirthday.Text);
                DBEntities.GetContext().SaveChanges();
                ClassMB.MBinformation("Успешно");
                this.NavigationService.Navigate(new AdminListPage());
            }
        }

        private void BnBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminListSotrPage());
        }
    }
}
