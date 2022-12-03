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
    /// Логика взаимодействия для AdminTarifAddPage.xaml
    /// </summary>
    public partial class AdminTarifAddPage : Page
    {
        public AdminTarifAddPage()
        {
            InitializeComponent();
        }
        Tarif tarif = new Tarif();
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

        private void BnSave_Click(object sender, RoutedEventArgs e)
        {
            if (TbNameTarif.Text != "" & TbGb.Text != "" &
                TbMinute.Text != "" & TbPrice.Text != "" & selectedFileName != null)
            {
                try
                {
                    var tarifAdd = new Tarif()
                    {
                        NameTarif = TbNameTarif.Text,
                        Gb = Convert.ToInt32(TbGb.Text),
                        Minute = Convert.ToInt32(TbMinute.Text),
                        Price = Convert.ToInt32(TbPrice.Text),
                        Image = LoadAndReadImageClass.ConvertImageToByteArray(selectedFileName)
                    };
                    DBEntities.GetContext().Tarif.Add(tarifAdd);
                    DBEntities.GetContext().SaveChanges();
                    this.NavigationService.Navigate(new TarifPage());
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
        private void LoadPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            AddPhoto();
        }
    }
}
