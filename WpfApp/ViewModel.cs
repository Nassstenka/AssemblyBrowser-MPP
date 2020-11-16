using AssemblyBrowsing;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace WpfApp
{
    class ViewModel : INotifyPropertyChanged
    {
        IDialogService dialogService;
        private Model model;
        private AssemblyInformation assembly;
        private RelayCommand openCommand;
        public AssemblyInformation Assembly
        {
            get { return assembly; }
            private set
            {
                assembly = value;
                OnPropertyChanged(nameof(Assembly));
            }
        }
        public RelayCommand OpenCommand
        {
            get
            {
                return openCommand ??
                  (openCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.OpenFileDialog() == true)
                          {
                              Assembly = model.LoadAssembly(dialogService.FilePath);
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }
        public ViewModel()
        {
            model = new Model();
            dialogService = new DefaultDialogService();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
