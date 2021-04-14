

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Calculator_Binding.Calculator_Model
{
   public  class Model_Calculator : INotifyPropertyChanged
    {     

        private string input_string = "";
        public string Input_string
        {
            get { return input_string; }
            set { input_string = value; OnPropertyChanged("Input_string"); }
        }
        private string last_line = "";
        public string Last_line
        {
            get { return last_line; }
            set { last_line = value; OnPropertyChanged("Last_line"); }
        }
        private double rezult;
        public double Rezult
        {
            get { return rezult; }
            set { rezult = value; OnPropertyChanged("Model"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
