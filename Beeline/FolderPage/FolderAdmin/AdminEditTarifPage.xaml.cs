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
    /// Логика взаимодействия для AdminEditTarifPage.xaml
    /// </summary>
    public partial class AdminEditTarifPage : Page
    {
        public AdminEditTarifPage(Tarif tarif)
        {
            InitializeComponent();
            DataContext = tarif;
        }
        string selectedFileName = "";
        Tarif tarif = new Tarif();
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
                    tarif.Image = LoadAndReadImageClass
                        .ConvertImageToByteArray(selectedFileName);
                    PhotoIm.Source = LoadAndReadImageClass
                        .ConvertByteArrayImage(tarif.Image);
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
                Tarif tarif = DBEntities.GetContext().Tarif.FirstOrDefault(s => s.IdTarif == ClassVariable.IdSotr);
                tarif.NameTarif = TbNameTarif.Text;
                tarif.Minute = Convert.ToInt32(TbMinute.Text);
                tarif.Gb = Convert.ToInt32(TbGb.Text);
                tarif.Price = Convert.ToInt32(TbPrice.Text);
                tarif.Image = LoadAndReadImageClass.ConvertImageToByteArray(selectedFileName);
                DBEntities.GetContext().SaveChanges();
                ClassMB.MBinformation("Успешно");
                this.NavigationService.Navigate(new TarifPage());
            }
            else
            {
                Tarif tarif = DBEntities.GetContext().Tarif.FirstOrDefault(s => s.IdTarif == ClassVariable.IdSotr);
                tarif.NameTarif = TbNameTarif.Text;
                tarif.Minute = Convert.ToInt32(TbMinute.Text);
                tarif.Gb = Convert.ToInt32(TbGb.Text);
                tarif.Price = Convert.ToInt32(TbPrice.Text);
                DBEntities.GetContext().SaveChanges();
                ClassMB.MBinformation("Успешно");
                this.NavigationService.Navigate(new TarifPage());
            }
        }

        private void BnBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new TarifPage());
        }
    }
}
