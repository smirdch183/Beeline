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
using System.Windows.Shapes;

namespace Beeline.FolderWindow
{
    /// <summary>
    /// Логика взаимодействия для MainFrameAuthorizationWindow.xaml
    /// </summary>
    public partial class MainFrameAuthorizationWindow : Window
    {
        public MainFrameAuthorizationWindow()
        {
            InitializeComponent();
            //MainFrame.Navigate(new FolderPage.AuthorizationPage());
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
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void CloseIm_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FolderClass.ClassMB.MBExit();
        }

        private void BnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbLogin.Text))
            {
                ClassMB.MBerror("Введите логин");
                TbLogin.Focus();
            }
            else if (string.IsNullOrEmpty(PbPassword.Password))
            {
                ClassMB.MBerror("Введите пароль");
                PbPassword.Focus();
            }
            else
            {
                try
                {
                    var user = DBEntities.GetContext().User.FirstOrDefault(u => u.Login == TbLogin.Text);
                    if (user == null)
                    {
                        ClassMB.MBerror("Введен не верный логин");
                        TbLogin.Focus();
                        return;
                    }
                    if (user.Password != PbPassword.Password)
                    {
                        ClassMB.MBerror("введен не верный пароль");
                        PbPassword.Focus();
                        return;
                    }
                    else
                    {
                        int iduser = user.IdUser;
                        var sotr = DBEntities.GetContext().Sotr.FirstOrDefault(s => s.IdUser == iduser);
                        int idsotr = sotr.IdSotr;
                        ClassGlobal.SotrId = idsotr;
                        ClassGlobal.RoleId = user.IdRole;
                        switch (user.IdRole)
                        {
                            case 1:
                                MainFrameWindow mainFrameWindow = new MainFrameWindow();
                                mainFrameWindow.Show();
                                Application.Current.MainWindow.Close();
                                break;
                            case 3:
                                MainFrameWindow mainFrameWindow0 = new MainFrameWindow();
                                mainFrameWindow0.Show();
                                Application.Current.MainWindow.Close();
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ClassMB.MBerror(ex);
                }
            }
        }
    }
}
