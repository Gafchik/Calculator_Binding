using System;
using System.Windows;
using System.Windows.Controls;
using Calculator_Binding.Calculator_Model;

namespace Calculator_Binding.Calculator_VewModel
{
    public class ViewModel_Calculator 
    {       
        internal void Calculate(Model_Calculator model)
        {
            int i = 0;
            bool IS_act = false; // флаг был ли обнаружен оператор
            char act = '+'; // переменная для хранения оператора примера
            string first_number = string.Empty; // первое число 
            string second_number = string.Empty; // второе число
            if(model.Input_string[0]== '-')
            { first_number += '-'; i = 1; }
            for ( ; i < model.Input_string.Length; i++) // цикил бежит по строке и сохраняет цифры и оператор
            {
                switch (model.Input_string[i])
                {
                    case '+':
                        IS_act = true;
                        act = model.Input_string[i];
                        break;
                    case '-':
                        IS_act = true;
                        act = model.Input_string[i];
                        break;
                    case '*':
                        IS_act = true;
                        act = model.Input_string[i];
                        break;
                    case '/':
                        IS_act = true;
                        act = model.Input_string[i];
                        break;
                    default:
                        if (!IS_act)
                            first_number += model.Input_string[i];
                        else
                            second_number += model.Input_string[i];

                        break;
                }               
            }
            try
            {
                switch (act) // свич для выбора мат действия и присваивание результатов
                {

                    case '+':
                        model.Rezult = double.Parse(first_number) + double.Parse(second_number);
                        break;
                    case '-':
                        model.Rezult = double.Parse(first_number) - double.Parse(second_number);
                        break;
                    case '*':
                        model.Rezult = double.Parse(first_number) * double.Parse(second_number);
                        break;
                    case '/':
                        if (double.Parse(second_number) != 0)
                            model.Rezult = double.Parse(first_number) / double.Parse(second_number);
                        else
                            throw new DivideByZeroException();
                        break;
                    default:
                        break;
                }
                model.Last_line = model.Input_string;
                model.Input_string = model.Rezult.ToString();
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("На 0 делить нельзя", "Дибил", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            catch (Exception)
            {

                MessageBox.Show("Что-то пошло не так", "Дибил", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
                       
            
        }

        internal  void Input(object sender, Model_Calculator model)
        {
            var key = (sender as Button);           
                switch (key.Content.ToString())
                {
                    case "+":
                         if (model.Input_string[0] == '-')
                            model.Input_string += key.Content.ToString();
                        else if (Find_op(model))
                            Calculate(model);
                        else
                            model.Input_string += key.Content.ToString();
                        break;
                    case "-":
                        if (Find_op(model))
                            Calculate(model);
                        else if (model.Input_string == "")
                            model.Input_string = "0-";
                        else
                            model.Input_string += key.Content.ToString();
                        break;
                    case "*":
                        if (model.Input_string[0] == '-')
                            model.Input_string += key.Content.ToString();
                        else if (Find_op(model))
                            Calculate(model);
                        else
                            model.Input_string += key.Content.ToString();
                        break;
                    case "/":
                        if (model.Input_string[0] == '-')
                            model.Input_string += key.Content.ToString();
                        else if (Find_op(model))
                            Calculate(model);
                        else
                            model.Input_string += key.Content.ToString();
                        break;
                    case "=":
                        if (Find_op(model))
                            Calculate(model);
                        else
                            model.Input_string += key.Content.ToString();
                        break;
                    case "C":
                        model.Input_string = "";
                        break;
                    case "<--":
                        model.Input_string = model.Input_string.Remove(model.Input_string.Length - 1);
                        break;


                    default:
                        model.Input_string += key.Content.ToString();
                        break;
                }                    
        }
        private bool Find_op(Model_Calculator model)
        {
            for (int i = 0; i < model.Input_string.Length; i++) // цикил бежит по строке и сохраняет цифры и оператор
            {
                switch (model.Input_string[i])
                {
                    case '+': return true;
                    case '-': return true;
                    case '*': return true;
                    case '/': return true;
                }
            }
            return false;
        }
    }
}
