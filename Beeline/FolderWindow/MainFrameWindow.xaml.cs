using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;
using Beeline.FolderClass;
using Beeline.FolderData;
using Beeline.FolderPage;
using Beeline.FolderPage.FolderAdmin;


namespace Beeline.FolderWindow
{
    /// <summary>
    /// Логика взаимодействия для MainFrameWindow.xaml
    /// </summary>
    public partial class MainFrameWindow : Window
    {
        public MainFrameWindow()
        {
            int a = ClassGlobal.SotrId;
            var idsotr = DBEntities.GetContext().Sotr.FirstOrDefault(r => r.IdSotr == a);
            int iduser = idsotr.IdUser;
            var useriduser = DBEntities.GetContext().User.FirstOrDefault(r => r.IdUser == iduser);
            int role = useriduser.IdRole;
            InitializeComponent();
            SotrIm.Visibility = Visibility.Collapsed;
            ClientIm.Visibility = Visibility.Collapsed;
            BnBack.Visibility = Visibility.Collapsed;
            //LbAdd.Visibility = Visibility.Collapsed;
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
             if (e.LeftButton == MouseButtonState.Pressed)
             {
                DragMove();
             }
        }

        private void RollUpIm_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseIm_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ClassMB.MBExit();
        }

        private void ClientIm_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int a = ClassGlobal.SotrId;
            var idsotr = DBEntities.GetContext().Sotr.FirstOrDefault(r => r.IdSotr == a);
            int iduser = idsotr.IdUser;
            var useriduser = DBEntities.GetContext().User.FirstOrDefault(r => r.IdUser == iduser);
            int role = useriduser.IdRole;
            if (role == 1)
            {
                MainFrame.Navigate(new AdminAddClientPage());
                
            }
            else
            {
                MainFrame.Navigate(new OperatorAddClientPage());
                
            }
        }

        private void SotrIm_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            CenterWindowOnScreen();
            MainFrame.Navigate(new AdminAddSotrPage());
            
        }

        private void HomeIm_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int a = ClassGlobal.SotrId;
            var idsotr = DBEntities.GetContext().Sotr.FirstOrDefault(r => r.IdSotr == a);
            int iduser = idsotr.IdUser;
            var useriduser = DBEntities.GetContext().User.FirstOrDefault(r => r.IdUser == iduser);
            int role = useriduser.IdRole;
            if (role == 1)
            {
                
                CenterWindowOnScreen();
                MainFrame.Navigate(new AdminListPage());
            }
            else
            {
                MainFrame.Navigate(new OperatorAddClientPage());
            }
        }

        private void TarifIm_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        

            MainFrame.Navigate(new TarifPage());
        }
        private void CenterWindowOnScreen()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        private void BnBack_Click(object sender, RoutedEventArgs e)
        {
            int a = ClassGlobal.SotrId;
            var idsotr = DBEntities.GetContext().Sotr.FirstOrDefault(r => r.IdSotr == a);
            int iduser = idsotr.IdUser;
            var useriduser = DBEntities.GetContext().User.FirstOrDefault(r => r.IdUser == iduser);
            int role = useriduser.IdRole;
            BnBack.Visibility = Visibility.Collapsed;
            HomeIm.Visibility = Visibility.Visible;
            ClientIm.Visibility = Visibility.Visible;
            SotrIm.Visibility = Visibility.Visible;
            TarifIm.Visibility = Visibility.Visible;
            SotrSIm.Visibility = Visibility.Visible;
            DogovorIm.Visibility = Visibility.Visible;
            TarifAddIm.Visibility = Visibility.Visible;
            if (role == 1)
            {
                //this.Width = 1250;
                //this.Height = 600;
                CenterWindowOnScreen();
                MainFrame.Navigate(new AdminListPage());
            }
            else if (role == 2)
            {
                MainFrame.Navigate(new OperatorAddClientPage());
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (ClassGlobal.RoleId == 1)
            {
                //this.Width = 1250;
                //this.Height = 600;
                CenterWindowOnScreen();
                MainFrame.Navigate(new AdminListPage());
                SotrIm.Visibility = Visibility.Visible;
                ClientIm.Visibility = Visibility.Visible;
                SotrSIm.Visibility = Visibility.Visible;
                DogovorIm.Visibility = Visibility.Visible;
                TarifAddIm.Visibility = Visibility.Visible;
                BnBack.Visibility = Visibility.Collapsed;
                HomeIm.Visibility = Visibility.Visible;
                ClientIm.Visibility = Visibility.Visible;
                SotrIm.Visibility = Visibility.Visible;
                TarifIm.Visibility = Visibility.Visible;
            }
            else
            {
                CenterWindowOnScreen();
                MainFrame.Navigate(new OperatorAddClientPage());
                BnBack.Visibility = Visibility.Collapsed;
                HomeIm.Visibility = Visibility.Visible;
                ClientIm.Visibility = Visibility.Collapsed;
                SotrIm.Visibility = Visibility.Collapsed;
                TarifIm.Visibility = Visibility.Visible;
                SotrSIm.Visibility = Visibility.Collapsed;
                DogovorIm.Visibility = Visibility.Collapsed;
                TarifAddIm.Visibility = Visibility.Collapsed;
            }
        }

        private void SotrSIm_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CenterWindowOnScreen();
            MainFrame.Navigate(new AdminListSotrPage());
        }

        private void DogovorIm_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CenterWindowOnScreen();
            MainFrame.Navigate(new AdminDogovorPage());
        }

        private void TarifAddIm_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CenterWindowOnScreen();
            MainFrame.Navigate(new AdminTarifAddPage());
        }
    }
}
