using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Beeline.FolderClass
{
    internal class ClassMB
    {
        public static void MBerror(Exception text)
        {
            MessageBox.Show(text.Message, "Ошибка",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static void MBerror(string text)
        {
            MessageBox.Show(text, "Ошибка",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static void MBinformation(string textMessage)
        {
            MessageBox.Show(textMessage, "Информация",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public static bool QuestionMessage(string text)
        {
            return MessageBoxResult.Yes == MessageBox.Show(text, "Вопрос",
                MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
        public static void MBExit()
        {
            bool resultMB = QuestionMessage("Вы действительно хотите выйти?");
            if(resultMB == true)
            {
                App.Current.Shutdown();
            }
        }

    }
}
