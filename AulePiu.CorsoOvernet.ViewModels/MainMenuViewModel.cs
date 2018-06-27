using AulePiu.CorsoOvernet.DomainModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace AulePiu.CorsoOvernet.ViewModels
{
    public class MainMenuViewModel : ViewModelBase
    {
        public ObservableCollection<MachineViewModel> Items { get; set; }

        public RelayCommand<MachineViewModel> ResetCommand { get; set; }
        public RelayCommand AddCommand { get; set; }

        private int maximumWorkHours;
        public int MaximumWorkHours
        {
            get { return maximumWorkHours; }
            set
            {
                maximumWorkHours = value;
                base.RaisePropertyChanged();
            }
        }

        private MachineViewModel item;
        public MachineViewModel Item
        {
            get { return item; }
            set
            {
                item = value;
                base.RaisePropertyChanged();
            }
        }

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value;
                base.RaisePropertyChanged();
                this.AddCommand.RaiseCanExecuteChanged();
            }
        }

        public MainMenuViewModel()
        {
            this.ResetCommand = new RelayCommand<MachineViewModel>(resetCommandExecute);
            this.AddCommand = new RelayCommand(addCommandExecute, addCommandCanExecute);
            this.MaximumWorkHours = 10000;
            this.Items = new ObservableCollection<MachineViewModel>();
            //this.Items.Add(new Machine()
            //    { ID = 1, Code = "COD1", Name = "Mattia", WorkHours = 100 });
            //this.Items.Add(new Machine()
            //    { ID = 2, Code = "COD2", Name = "Nadia", WorkHours = 200 });
            //this.Items.Add(new Machine()
            //    { ID = 3, Code = "COD3", Name = "Alberto", WorkHours = 300 });
            load();
        }

        private bool addCommandCanExecute()
        {
            return !this.IsBusy;
        }

        private async void addCommandExecute()
        {
            this.IsBusy = true;

            await Task.Run(() => {

                // Attesa "inutile"

                int id = Thread.CurrentThread.ManagedThreadId;
                Debug.WriteLine(id);

                Random rnd = new Random((int)DateTime.Now.Ticks);
                int number = 10000000;
                List<MachineViewModel> cache = new List<MachineViewModel>();
                cache.AddRange(this.Items);

                for (int i = 0; i < number; i++)
                {
                    MachineViewModel m = new MachineViewModel(new Machine());
                    m.Code = "COD";
                    m.WorkHours = rnd.Next(1, this.MaximumWorkHours);
                    cache.Add(m);
                }

                this.Items = new ObservableCollection<MachineViewModel>(cache);
                base.RaisePropertyChanged(nameof(Items));
            });

            this.IsBusy = false;
        }

        private void resetCommandExecute(MachineViewModel parameter)
        {
            parameter.WorkHours = 0;
        }

        private void load()
        {
            string filename = @"Z:\MyData\OneDrive\Corsi\WPF\MachineData.txt";

            if (File.Exists(filename))
            {
                string[] parts;
                string[] csvContent = File.ReadAllLines(filename);

                foreach (var line in csvContent)
                {
                    parts = line.Split(new char[] { ';' });

                    Machine machine = new Machine();
                    machine.ID = Int32.Parse(parts[0]);
                    machine.Code = parts[1];
                    machine.Name = parts[2];
                    machine.WorkHours = Int32.Parse(parts[3]);

                    MachineViewModel vm = new MachineViewModel(machine);
                    this.Items.Add(vm);
                }

                this.Item = this.Items[0];
            }
        }
    }
}