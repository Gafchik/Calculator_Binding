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
        internal void Calculate(string input_str)
        {
            model.input_string = input_str; // присваиваем входящюю строке с вью в модель
            bool IS_act = false; // флаг был ли обнаружен оператор
            char act = '+'; // переменная для хранения оператора примера
            string first_number = string.Empty; // первое число 
            string second_number = string.Empty; // второе число
            for (int i = 0; i < model.input_string.Length; i++) // цикил бежит по строке и сохраняет цифры и оператор
            {
                switch (model.input_string[i])
                {
                    case '+':
                        IS_act = true;
                        act = model.input_string[i];
                        break;
                    case '-':
                        IS_act = true;
                        act = model.input_string[i];
                        break;
                    case '*':
                        IS_act = true;
                        act = model.input_string[i];
                        break;
                    case '/':
                        IS_act = true;
                        act = model.input_string[i];
                        break;
                    default:
                        if (!IS_act)
                            first_number += model.input_string[i];
                        else
                            second_number += model.input_string[i];

                        break;
                }               
            }
            switch (act) // свич для выбора мат действия и присваивание результатов
            {
                case '+':
                    model.rezult = double.Parse(first_number) + double.Parse(second_number);
                    break;
                case '-':
                    model.rezult = double.Parse(first_number) - double.Parse(second_number);
                    break;
                case '*':
                    model.rezult = double.Parse(first_number) * double.Parse(second_number);
                    break;
                case '/':
                    if (double.Parse(second_number) != 0)
                        model.rezult = double.Parse(first_number) / double.Parse(second_number);
                    else
                        throw new DivideByZeroException();
                    break;
                default:
                    break;
            }
        }
    }
}
