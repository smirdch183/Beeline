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
using Beeline.FolderClass;
using Beeline.FolderData;
using Beeline.FolderPage;
using Beeline.FolderPage.FolderAdmin;
using Beeline.FolderWindow;

namespace Beeline.FolderWindow
{
    /// <summary>
    /// Логика взаимодействия для MainFrameAddWindow.xaml
    /// </summary>
    public partial class MainFrameAddWindow : Window
    {
        public MainFrameAddWindow()
        {
            int a = ClassGlobal.SotrId;
            int b = ClassGlobal.Window;
            var idsotr = DBEntities.GetContext().Sotr.FirstOrDefault(r => r.IdSotr == a);
            int iduser = idsotr.IdUser;
            var useriduser = DBEntities.GetContext().User.FirstOrDefault(r => r.IdUser == iduser);
            int role = useriduser.IdRole;
            InitializeComponent();
            if (role == 1 & b == 1)
            {
                
                MainFrame.Navigate(new AdminAddClientDogovorPage());
                
            }
            else if (role == 1 & b == 2)
            {
                MainFrame.Navigate(new AdminAddSotrProdolgPage());
            }
            else
            {
                MainFrame.Navigate(new OperstorAddClientDogovorPage());
            }
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

        
    }
}
