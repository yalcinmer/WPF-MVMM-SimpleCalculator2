using MVMM_ICommand5.Commands;
using MVMM_ICommand5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVMM_ICommand5.ViewModels
{
    public class SimpleCalViewModel : SimpleCalViewBase
    {
        SimpleCalModel model;
        string display;
        string lastOperation;
        public SimpleCalViewModel()
        {
            model = new SimpleCalModel();
            FirstNumber = "";
            SecondNumber = "";
            Operation = "";
            Display = "0";
        }
        public string FirstNumber
        {
            get { return model.FirstNumber; }
            set
            {
                model.FirstNumber = value;
                OnPropertyChanged("FirstNumber");
            }
        }

        public string SecondNumber
        {
            get { return model.SecondNumber; }
            set
            {
                model.SecondNumber = value;
                OnPropertyChanged("SecondNumber");
            }
        }

        public string Operation
        {
            get { return model.Operation; }
            set { model.Operation = value; }
        }

        public string Result
        {
            get { return model.Result; }
        }

        public string Display
        {
            get { return display; }
            set
            {
                display = value;
                OnPropertyChanged("Display");
            }
        }

        public string LastOperation
        {
            get { return lastOperation; }
            set { lastOperation = value; }
        }

        public void ButtonPress(string button)
        {
            try
            {
                if(FirstNumber == null || SecondNumber == null || LastOperation == "=")
                    lastOperation = button;
                else
                {
                    Operation = lastOperation;
                    model.Calculate();
                    LastOperation = button;
                    Display = Result;
                }
            }
            catch
            {
                throw new Exception();
            }
           
        }

        private ICommand buttonPressCommand;
        public ICommand ButtonPressCommand
        {
            get
            {
                if (buttonPressCommand == null)
                    buttonPressCommand = new RelayCommand<string>(ButtonPress);
                return buttonPressCommand;

            }
        }


    }
}
