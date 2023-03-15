using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
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
using DataAccessLibrary.Net.Models;
using System.Net;

namespace WPFUIPractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            searchByDropDown.ItemsSource = new List<string> { "First Name", "Last Name", "Email Address", "" };
            searchByDropDown.SelectedIndex = 3;


            //persons.Add(new BasicPersonModel { FirstName = "Sorin", LastName = "Axente", EmailAddress = "sorin@axente.com", PhoneNumber = "0744123123", IsActive = 1 });
            //persons.Add(new BasicPersonModel { FirstName = "Vasile", LastName = "Japca", EmailAddress = "vasile@japca.com", PhoneNumber = "0755321321", IsActive = 1 });

        }

        SqlCrud sql = new SqlCrud(GetConnectionString());


        private  List<BasicPersonModel> ReadAllPersons(SqlCrud sql)
        {
            List<BasicPersonModel> persons = new List<BasicPersonModel>();
            var rows = sql.GetAllPersons();
            foreach (var row in rows)
            {
                BasicPersonModel person = new BasicPersonModel
                {
                    Id = row.Id,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    EmailAddress = row.EmailAddress,
                    PhoneNumber = row.PhoneNumber,
                    IsActive = row.IsActive
                };
               
                persons.Add(person);
            }
           return persons;
        }

        private List<AddressModel> AddressesByPersonId(SqlCrud sql, int personId)
        {
            FullPersonModel person = new FullPersonModel();
            
            List<AddressModel> addresses = new List<AddressModel>();

            person = sql.GetAddressesByPersonId(personId);

            foreach (AddressModel address in person.Addresses)

            {
                AddressModel personAddress = new AddressModel
                {
                    Id = address.Id,
                    StreetNumber = address.StreetNumber,
                    StreetName = address.StreetName,
                    City = address.City,
                    Country = address.Country,
                    Postcode = address.Postcode,
                };
                addresses.Add(personAddress);
            }
            return addresses;
        }


            private void createOrderButton_Click(object sender, RoutedEventArgs e)
        {
            CreateOrder order = new CreateOrder();
            order.Show();
        }

        private void createPersonButton_Click(object sender, RoutedEventArgs e)
        {
            CreatePerson person = new CreatePerson();
            person.Show();
        }

        private static string GetConnectionString(string connectionStringName = "Default")
        {
            string output = "";

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            output = config.GetConnectionString(connectionStringName);

            return output;
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            List<BasicPersonModel> persons = new List<BasicPersonModel>();
            List<BasicPersonModel> searchedPersons = new List<BasicPersonModel>();
            persons = ReadAllPersons(sql);


            if  (searchByDropDown.SelectedItem.ToString() == "" )
            {
                searchResults.ItemsSource = persons;
            }
            else if (searchByDropDown.SelectedItem.ToString() == "First Name")
            {
                foreach (BasicPersonModel person in persons)
                {
                    if (searchByTextBox.Text.ToLower() == person.FirstName.ToLower())
                    {
                        searchedPersons.Add(person);
                    }
                }
                searchResults.ItemsSource = searchedPersons;
            }
            else if (searchByDropDown.SelectedItem.ToString() == "Last Name")
            {
                foreach (BasicPersonModel person in persons)
                {
                    if (searchByTextBox.Text.ToLower() == person.LastName.ToLower())
                    {
                        searchedPersons.Add(person);
                    }
                }
                searchResults.ItemsSource = searchedPersons;
            }
            else if (searchByDropDown.SelectedItem.ToString() == "Email Address")
            {
                foreach (BasicPersonModel person in persons)
                {
                    if (searchByTextBox.Text.ToLower() == person.EmailAddress.ToLower())
                    {
                        searchedPersons.Add(person);
                    }
                }
                searchResults.ItemsSource = searchedPersons;
            }
        }

        private void showAddressesButton_Click(object sender, RoutedEventArgs e)
        {
            BasicPersonModel person= new BasicPersonModel();

            if ( searchResults.SelectedItems.Count == 1)
            {
                person = searchResults.SelectedItem as BasicPersonModel;
                selectedPersonAddressListBox.ItemsSource = AddressesByPersonId(sql, person.Id);
            }
            else if (searchResults.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a person");
            }
            else if (searchResults.SelectedItems.Count > 1)
            {
                MessageBox.Show("Please select only one person");
            }
           

        }
    }
}
