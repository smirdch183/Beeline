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
using Microsoft.Win32;

namespace Beeline.FolderPage.FolderAdmin
{
    /// <summary>
    /// Логика взаимодействия для AdminEditPage.xaml
    /// </summary>
    public partial class AdminEditPage : Page
    {
        Client clients = new Client();
        public AdminEditPage(Dogovor dogovor)
        {
            InitializeComponent();
            clients = DBEntities.GetContext().Client.Find(dogovor.IdClient);
            DpDateOfIssue.SelectedDate = clients.DateOfIssue;
            DataContext = dogovor;
            CbTarif.ItemsSource = DBEntities.GetContext().Tarif.ToList().OrderBy(t => t.IdTarif);
            CbStatus.ItemsSource = DBEntities.GetContext().Status.ToList().OrderBy(s => s.IdStatus);
        }
        string selectedFileName = "";
        Client client = new Client();
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
                    client.Image = LoadAndReadImageClass
                        .ConvertImageToByteArray(selectedFileName);
                    PhotoIm.Source = LoadAndReadImageClass
                        .ConvertByteArrayImage(client.Image);
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
                Dogovor dogovor = DBEntities.GetContext().Dogovor
                    .FirstOrDefault(s => s.IdDogovor == ClassVariable.IdDogovor);
                dogovor.Client.LastName = TbLastName.Text;
                dogovor.Client.FirstName = TbFirstName.Text;
                dogovor.Client.MidleName = TbMidleName.Text;
                dogovor.Client.Phone = TbPhone.Text;
                dogovor.Client.Email = TbEmail.Text;
                dogovor.Client.SeriesAndNumber = TbSeriesAndNumber.Text;
                dogovor.Client.DateOfIssue = DateTime.Parse(DpDateOfIssue.Text);
                dogovor.Client.Birthday = DateTime.Parse(DpBirthday.Text);
                dogovor.IdTarif = Int32.Parse(CbTarif.SelectedValue.ToString());
                dogovor.IdStatus = Int32.Parse(CbStatus.SelectedValue.ToString());
                dogovor.Client.Image = LoadAndReadImageClass.ConvertImageToByteArray(selectedFileName);
                DBEntities.GetContext().SaveChanges();
                ClassMB.MBinformation("Успешно");
                this.NavigationService.Navigate(new AdminListPage());
            }
            else
            {
                Dogovor dogovor = DBEntities.GetContext().Dogovor
                   .FirstOrDefault(s => s.IdDogovor == ClassVariable.IdDogovor);
                dogovor.Client.LastName = TbLastName.Text;
                dogovor.Client.FirstName = TbFirstName.Text;
                dogovor.Client.MidleName = TbMidleName.Text;
                dogovor.Client.Phone = TbPhone.Text;
                dogovor.Client.Email = TbEmail.Text;
                dogovor.Client.SeriesAndNumber = TbSeriesAndNumber.Text;
                dogovor.Client.DateOfIssue = DateTime.Parse(DpDateOfIssue.Text);
                dogovor.Client.Birthday = DateTime.Parse(DpBirthday.Text);
                dogovor.IdTarif = Int32.Parse(CbTarif.SelectedValue.ToString());
                dogovor.IdStatus = Int32.Parse(CbStatus.SelectedValue.ToString());
                DBEntities.GetContext().SaveChanges();
                ClassMB.MBinformation("Успешно");
                this.NavigationService.Navigate(new AdminListPage());
            }
        }

        private void BnBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminListPage());
        }
    }
}
