using Beeline.FolderClass;
using Beeline.FolderData;
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
using Beeline.FolderPage.FolderAdmin;

namespace Beeline.FolderPage.FolderAdmin
{
    /// <summary>
    /// Логика взаимодействия для AdminListSotrPage.xaml
    /// </summary>
    public partial class AdminListSotrPage : Page
    {
        public AdminListSotrPage()
        {
            InitializeComponent();
            LbSotr.ItemsSource = DBEntities.GetContext().Sotr.ToList();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                LbSotr.ItemsSource = DBEntities.GetContext().Sotr
                    .Where(c => c.Phone.StartsWith(SearchTb.Text)
                    || c.LastName.StartsWith(SearchTb.Text)).ToList();
            }
            catch (Exception ex)
            {
                ClassMB.MBerror(ex);
            }
        }
        private void LbDogovor_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //if (LbSotr.SelectedItem == null)
            //{
            //    ClassMB.MBerror("Не выбран клиент для редактирования");
            //}
            //else
            //{
            //    Sotr sotr = LbSotr.SelectedItem as Sotr;
            //    ClassVariable.IdSotr = sotr.IdSotr;
            //    this.NavigationService.Navigate(new AdminEditSotrPage(LbSotr.SelectedItem as Sotr));
            //    LbSotr.ItemsSource = DBEntities.GetContext().Dogovor.ToList().
            //    OrderBy(c => c.IdClient);
            //}
        }

        private void BnTestEdit_Click(object sender, RoutedEventArgs e)
        {
            if (LbSotr.SelectedItem == null)
            {
                ClassMB.MBerror("Не выбран клиент для редактирования");
            }
            else
            {
                Sotr sotr = LbSotr.SelectedItem as Sotr;
                ClassVariable.IdSotr = sotr.IdSotr;
                this.NavigationService.Navigate(new AdminEditSotrPage(LbSotr.SelectedItem as Sotr));
                LbSotr.ItemsSource = DBEntities.GetContext().Dogovor.ToList().
                OrderBy(c => c.IdClient);
            }
        }

        private void BnBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminListPage());
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            if (LbSotr.SelectedItem == null)
            {
                ClassMB.MBerror("Не выбран клиент для редактирования");
            }
            else
            {
                Sotr sotr = LbSotr.SelectedItem as Sotr;
                ClassVariable.IdSotr = sotr.IdSotr;
                this.NavigationService.Navigate(new AdminEditSotrPage(LbSotr.SelectedItem as Sotr));
                LbSotr.ItemsSource = DBEntities.GetContext().Dogovor.ToList().
                OrderBy(c => c.IdClient);
            }
        }
    }
}
