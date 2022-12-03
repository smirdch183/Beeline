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
using Beeline.FolderClass;
using Beeline.FolderData;

namespace Beeline.FolderPage.FolderAdmin
{
    /// <summary>
    /// Логика взаимодействия для AdminAddClientDogovorPage.xaml
    /// </summary>
    public partial class AdminAddClientDogovorPage : Page
    {
        public AdminAddClientDogovorPage()
        {
            InitializeComponent();
            DgList.ItemsSource = DBEntities.GetContext().Tarif.ToList().OrderBy(t => t.IdTarif);
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
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (DgList.SelectedItem == null)
            {
                ClassMB.MBerror("Не выбран тариф для добавление");
            }
            else
            {
                Tarif tarif = DgList.SelectedItem as Tarif;
                ClassVariable.IdTarif = tarif.IdTarif;
                int id = tarif.IdTarif;
                DBEntities.GetContext().Dogovor.Add(new Dogovor()
                {
                    IdTarif = id,
                    IdClient = ClassGlobal.ClientId,
                    IdSotr = ClassGlobal.SotrId,
                    IdStatus = 3
                });
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
        }
    }
}
