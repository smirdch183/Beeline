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

namespace Beeline.FolderPage.FolderAdmin
{
    /// <summary>
    /// Логика взаимодействия для AdminListPage.xaml
    /// </summary>
    public partial class AdminListPage : Page
    {
        public AdminListPage()
        {
            InitializeComponent();
            DGClient.ItemsSource = DBEntities.GetContext().Dogovor.ToList().OrderBy(d => d.IdDogovor);
            LbDogovor.ItemsSource = DBEntities.GetContext().Dogovor.ToList();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                LbDogovor.ItemsSource = DBEntities.GetContext().Dogovor
                    .Where(c => c.Client.Phone.StartsWith(SearchTb.Text)
                    || c.Client.LastName.StartsWith(SearchTb.Text)).ToList();
            }
            catch (Exception ex)
            {
                ClassMB.MBerror(ex);
            }
        }
        //private void BnInfo_Click(object sender, RoutedEventArgs e)
        //{
        //    if (LbDogovor.SelectedItem == null)
        //    {
        //        ClassMB.MBerror("Не выбран клиент для просмотра информации");
        //    }
        //    else
        //    {
        //        try
        //        {
        //            int a;
        //            string b, c, d;
        //            Dogovor dogovor = LbDogovor.SelectedItem as Dogovor;
        //            ClassVariable.IdDogovor = dogovor.IdDogovor;
        //            a = dogovor.IdSotr;
        //            var sotr = DBEntities.GetContext().Sotr.FirstOrDefault(s => s.IdSotr == a);
        //            b = Convert.ToString(sotr.LastName);
        //            c = Convert.ToString(sotr.FirstName);
        //            d = Convert.ToString(sotr.MidleName);
        //            ClassMB.MBinformation(b + " " + c + " " + d);
        //        }
        //        catch (Exception ex)
        //        {
        //            ClassMB.MBerror(ex);
        //        }
        //    }
        //}
        private void LbDogovor_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //if (LbDogovor.SelectedItem == null)
            //{
            //    ClassMB.MBerror("Не выбран клиент для редактирования");
            //}
            //else
            //{
                //Dogovor dogovor = LbDogovor.SelectedItem as Dogovor;
                //ClassVariable.IdDogovor = dogovor.IdDogovor;
                //this.NavigationService.Navigate(new AdminEditPage(LbDogovor.SelectedItem as Dogovor));
                ////new AdminEditWindow(DgList.SelectedItem as Dogovor).Show();
                //LbDogovor.ItemsSource = DBEntities.GetContext().Dogovor.ToList().
                //OrderBy(c => c.IdClient);
           // }
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            if (LbDogovor.SelectedItem == null)
            {
                ClassMB.MBerror("Не выбран клиент для редактирования");
            }
            else
            {
                Dogovor dogovor = LbDogovor.SelectedItem as Dogovor;
                ClassVariable.IdDogovor = dogovor.IdDogovor;
                this.NavigationService.Navigate(new AdminEditPage(LbDogovor.SelectedItem as Dogovor));
                //new AdminEditWindow(DgList.SelectedItem as Dogovor).Show();
                LbDogovor.ItemsSource = DBEntities.GetContext().Dogovor.ToList().
                OrderBy(c => c.IdClient);
            }
        }

        private void BnTestEdit_Click(object sender, RoutedEventArgs e)
        {
            //if (LbDogovor.SelectedItem == null)
            //{
            //    ClassMB.MBerror("Не выбран клиент для редактирования");
            //}
            //else
            //{
            //    Dogovor dogovor = LbDogovor.SelectedItem as Dogovor;
            //    ClassVariable.IdDogovor = dogovor.IdDogovor;
            //    this.NavigationService.Navigate(new AdminEditPage(LbDogovor.SelectedItem as Dogovor));
            //    //new AdminEditWindow(DgList.SelectedItem as Dogovor).Show();
            //    LbDogovor.ItemsSource = DBEntities.GetContext().Dogovor.ToList().
            //    OrderBy(c => c.IdClient);
            //}
        }

        //private void BnSotr_Click(object sender, RoutedEventArgs e)
        //{
        //    this.NavigationService.Navigate(new AdminListSotrPage());
        //}

        private void ImportBtn_Click(object sender, RoutedEventArgs e)
        {
            ClassExport.ToExcelFile(DGClient,"Клиенты");
        }
    }
}
