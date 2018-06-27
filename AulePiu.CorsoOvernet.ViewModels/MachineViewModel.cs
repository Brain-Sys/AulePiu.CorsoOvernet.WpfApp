using AulePiu.CorsoOvernet.DomainModel;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulePiu.CorsoOvernet.ViewModels
{
    public class MachineViewModel : ViewModelBase
    {
        public Machine Instance { get; private set; }

        public int ID
        {
            get
            {
                return Instance.ID;
            }
            set
            {
                Instance.ID = value;
                base.RaisePropertyChanged();
            }
        }

        public string Code
        {
            get
            {
                return Instance.Code;
            }
            set
            {
                Instance.Code = value;
                base.RaisePropertyChanged();
            }
        }

        public int WorkHours
        {
            get
            {
                return Instance.WorkHours;
            }
            set
            {
                Instance.WorkHours = value;
                base.RaisePropertyChanged();
            }
        }

        public MachineViewModel(Machine machine)
        {
            this.Instance = machine;
        }
    }
}