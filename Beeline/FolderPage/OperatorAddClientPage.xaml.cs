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
using Beeline.FolderClass;
using Beeline.FolderPage;
using Beeline.FolderWindow;
using Microsoft.Win32;

namespace Beeline.FolderPage
{
    /// <summary>
    /// Логика взаимодействия для OperatorAddClientPage.xaml
    /// </summary>
    public partial class OperatorAddClientPage : Page
    {
        Client client = new Client();
        public OperatorAddClientPage()
        {
            InitializeComponent();
            CbPhone.ItemsSource = DBEntities.GetContext().Phone
                    .Where(c => c.StatusPhone.NameStatusPhone.StartsWith("Не занят")
                    || c.StatusPhone.NameStatusPhone.StartsWith("Не занят")).ToList();
            //DgList.ItemsSource = DBEntities.GetContext().Tarif.ToList().OrderBy(t => t.IdTarif);
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
        private void BnSave_Click(object sender, RoutedEventArgs e)
        {
            if (TbLastName.Text != "" & TbFirstName.Text != "" &
                CbPhone.Text != "" & DpBirthday.Text != "" &
                TbSeriesAndNumber.Text != "" & DpDateOfIssue.Text != "" & selectedFileName != null)
            {
                try
                {
                    var clientAdd = new Client()
                    {
                        LastName = TbLastName.Text,
                        FirstName = TbFirstName.Text,
                        MidleName = TbMidleName.Text,
                        Phone = CbPhone.Text,
                        Birthday = Convert.ToDateTime(DpBirthday.Text),
                        Email = TbEmail.Text,
                        SeriesAndNumber = TbSeriesAndNumber.Text,
                        DateOfIssue = Convert.ToDateTime(DpDateOfIssue.Text),
                        Image = LoadAndReadImageClass.ConvertImageToByteArray(selectedFileName)
                    };
                    DBEntities.GetContext().Client.Add(clientAdd);
                    var phone = DBEntities.GetContext().Phone.FirstOrDefault(p => p.Number == CbPhone.Text);
                    phone.IdStatusPhone = 1;
                    DBEntities.GetContext().SaveChanges();
                    client.IdClient = clientAdd.IdClient;
                    ClassGlobal.ClientId = client.IdClient;
                    //AddClient.Visibility = Visibility.Hidden;
                    LoadPage();
                    //AddTariff.Visibility = Visibility.Visible;
                    NavigationService.Navigate(new OperstorAddClientDogovorPage());
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
        //private void BtnSave_Click(object sender, RoutedEventArgs e)
        //{
        //    if (DgList.SelectedItem == null)
        //    {
        //        ClassMB.MBerror("Не выбран тариф для добавление");
        //    }
        //    else
        //    {
        //        Tarif tarif = DgList.SelectedItem as Tarif;
        //        ClassVariable.IdTarif = tarif.IdTarif;
        //        int id = tarif.IdTarif;
        //        DBEntities.GetContext().Dogovor.Add(new Dogovor()
        //        {
        //            IdTarif = id,
        //            IdClient = ClassGlobal.ClientId,
        //            IdSotr = ClassGlobal.SotrId,
        //            IdStatus = 3
        //        });
        //        DBEntities.GetContext().SaveChanges();
        //        ClassMB.MBinformation("Успешно");
        //        this.NavigationService.Navigate(new OperatorAddClientPage());
        //    }
        //}
        MainFrameWindow mainFrameWindow = new MainFrameWindow();
        private void LoadPage()
        {

            mainFrameWindow.SpButton.Visibility = Visibility.Collapsed;
        }
        private void LoadPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            AddPhoto();
        }
    }
}
