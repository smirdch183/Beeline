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

namespace Beeline.FolderPage.FolderAdmin
{
    /// <summary>
    /// Логика взаимодействия для AdminDogovorPage.xaml
    /// </summary>
    public partial class AdminDogovorPage : Page
    {
        public AdminDogovorPage()
        {
            InitializeComponent();
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
    }
}
