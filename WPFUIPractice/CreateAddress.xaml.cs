using DataAccessLibrary.Net.Models;
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

namespace WPFUIPractice
{
    /// <summary>
    /// Interaction logic for CreateAddress.xaml
    /// </summary>
    public partial class CreateAddress : Window
    {
        public CreateAddress()
        {
            InitializeComponent();
        }

        private void saveAddress_Click(object sender, RoutedEventArgs e)
        {
            AddressModel address = new AddressModel();

        }
    }
}
