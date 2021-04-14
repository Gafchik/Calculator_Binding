using Calculator_Binding.Calculator_Model;
using Calculator_Binding.Calculator_VewModel;
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

namespace Calculator_Binding
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model_Calculator model;
        ViewModel_Calculator viewModel_;
        public MainWindow()
        {
            model = new Model_Calculator();
            viewModel_ = new ViewModel_Calculator();
            InitializeComponent();           
            DataContext = model;
            foreach (UIElement el in Grid.Children)
            {
                if(el is Button)
                    (el as Button).Click += Grid_Button_Click;
            }
            
        }

        private void Grid_Button_Click(object sender, RoutedEventArgs e) => viewModel_.Input(sender, model);


    }
}
