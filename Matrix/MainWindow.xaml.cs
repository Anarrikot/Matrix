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
using System.Data;

namespace Matrix
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            win2 win2 = new win2(Convert.ToInt32(xMat1.Text), Convert.ToInt32(yMat1.Text), Convert.ToInt32(xMat2.Text), Convert.ToInt32(yMat2.Text), cb.SelectedIndex);
            this.Close();
            win2.Show();
            
        }
    }
}
