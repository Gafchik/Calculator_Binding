using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Calculator_Binding.Calculator_Model;

namespace Calculator_Binding.Calculator_VewModel
{
    public class VewModel_Calculator : INotifyPropertyChanged
    {
        private Model_Calculator model;
        
        public Model_Calculator Model
        {
            get { return model; }
            set { model = value; OnPropertyChanged("Model"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
