﻿using System;
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
    /// Interaction logic for CreatePerson.xaml
    /// </summary>
    public partial class CreatePerson : Window
    {
        public CreatePerson()
        {
            InitializeComponent();
        }

        private void createAddress_Click(object sender, RoutedEventArgs e)
        {
            CreateAddress address = new CreateAddress();
            address.Show();
        }
    }
}
