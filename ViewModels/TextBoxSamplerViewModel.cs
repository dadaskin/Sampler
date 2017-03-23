using System.Windows;
using System.Windows.Input;
using TextBoxSampler.Framework;

namespace TextBoxSampler.ViewModels
{
    class TextBoxSamplerViewModel
    {
        #region Properties

        public string FileName { get; set; }
        public string Description { get; set; }
        public string ChemicalName { get; set; }
        public string InitialConcentration { get; set; }
        public string TargetConcentration { get; set; }
        public string InitialVolume { get; set; }
        public string TargetVolume { get; set; }

        #endregion Properties

        #region Read Command

        private ICommand _readCommand;

        public ICommand ReadCommand
        {
            get
            {
                if (_readCommand == null)
                    _readCommand = new RelayCommand(x=>ExecuteRead(), x=>CanExecuteRead());
                return _readCommand;
            }
        }   

        private void ExecuteRead()
        {
            MessageBox.Show("Foo!");
        }

        private bool CanExecuteRead()
        {
            return true;
        }

        #endregion Read Command

        #region Validation

        #endregion Validation
    }
}
