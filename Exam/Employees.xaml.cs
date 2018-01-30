using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Exam
{
    /// <summary>
    /// Interaction logic for Employees.xaml
    /// </summary>
    public partial class Employees : Page
    {
        private ObservableCollection<Employee> employees;
        public Employees()
        {
            InitializeComponent();

            employees = new ObservableCollection<Employee>()
            {
                new Employee
                {
                    Id = 1,
                    FullName = "Ким Олег Павлович",
                    Position = "директор"
                },
                new Employee
                {
                    Id = 2,
                    FullName = "Тен Павел Юрьевич",
                    Position = "разработчик"
                }
            };

            dataContainer.ItemsSource = employees;
        }

        private void ButtonInfoClick(object sender, RoutedEventArgs e)
        {
            //сериализация userList в файл (json)
            //List<Employee> userList = File.Exists(@"C:\name_of_folder\data.json") ? JsonConvert.DeserializeObject<ObservableCollection<Employee>>(File.ReadAllText(@"C:\name_of_folder\data.json")) : new List<User>();

            if (!(Directory.Exists(@"C:\name_of_folder")))
            {
                Directory.CreateDirectory(@"C:\name_of_folder");
            }

            string json = JsonConvert.SerializeObject(employees);

            using (StreamWriter writer = new StreamWriter(@"C:\name_of_folder\data.json"))
            {
                writer.WriteLine(json);
            }

            //переход к Info странице
            Info infoPage = new Info();
            this.NavigationService.Navigate(infoPage);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string satr = "ert";
        }
    }
}
