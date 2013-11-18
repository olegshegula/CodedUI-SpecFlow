using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Calculator
{
    public class CalculatorViewModel : ViewModelBase
    {
        private int _screen;

        public RelayCommand Plus { get; private set; }
        public RelayCommand Equal { get; private set; }

        public int Screen
        {
            get { return _screen; }
            set
            {
                _screen = value;
                RaisePropertyChanged(() => Screen);
            }
        }

        public CalculatorViewModel()
        {
            Plus = new RelayCommand(() => Screen = 0);
            Equal = new RelayCommand(() => Screen = 120);
        }
    }
}
