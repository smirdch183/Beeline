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
using Beeline.FolderPage.FolderAdmin;

namespace Beeline.FolderPage
{
    /// <summary>
    /// Логика взаимодействия для TarifPage.xaml
    /// </summary>
    public partial class TarifPage : Page
    {
        public TarifPage()
        {
            InitializeComponent();
            int a = ClassGlobal.SotrId;
            var idsotr = DBEntities.GetContext().Sotr.FirstOrDefault(r => r.IdSotr == a);
            int iduser = idsotr.IdUser;
            var useriduser = DBEntities.GetContext().User.FirstOrDefault(r => r.IdUser == iduser);
            int role = useriduser.IdRole;
            InitializeComponent();
            //BnAddTarif.Visibility = Visibility.Collapsed;
            //if (role == 1)
            //{
            //BnAddTarif.Visibility = Visibility.Visible;
            //}
            TarifLv.ItemsSource = DBEntities.GetContext().Tarif.ToList();
        }

        private void BnAddTarif_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new FolderAdmin.AdminTarifAddPage());
        }

        private void TarifLv_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (TarifLv.SelectedItem == null)
            {
                ClassMB.MBerror("Не выбран тариф для просмотра информации");
            }
            else
            {
                try
                {
                    int a;
                    string b, c;
                    Tarif tarif = TarifLv.SelectedItem as Tarif;
                    ClassVariable.IdTarif = tarif.IdTarif;
                    a = tarif.IdTarif;
                    var sotr = DBEntities.GetContext().Tarif.FirstOrDefault(s => s.IdTarif == a);
                    b = Convert.ToString(sotr.Gb);
                    c = Convert.ToString(sotr.Minute);
                    ClassMB.MBinformation("Гб:" + b + " "+ "Минуты:" + c);
                }
                catch (Exception ex)
                {
                    ClassMB.MBerror(ex);
                }
            }
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            if (TarifLv.SelectedItem == null)
            {
                ClassMB.MBerror("Не выбран клиент для редактирования");
            }
            else
            {
                Tarif tarif = TarifLv.SelectedItem as Tarif;
                ClassVariable.IdTarif = tarif.IdTarif;
                this.NavigationService.Navigate(new AdminEditTarifPage(TarifLv.SelectedItem as Tarif));
                TarifLv.ItemsSource = DBEntities.GetContext().Tarif.ToList().
                OrderBy(c => c.IdTarif);
            }
        }
    }
}
