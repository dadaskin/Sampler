using System.Windows;
using System.Windows.Input;
using TextBoxSampler.Framework;
using TextBoxSampler.ViewModels;
using TextBoxSampler.Views;

namespace TextBoxSampler
{
    public class MainWindowViewModel
    {
        #region TextBox Sampler

        private RelayCommand _displayTextBoxSampler;

        public ICommand DisplayTextBoxSamplerCommand
        {
            get
            {
                if (_displayTextBoxSampler == null)
                    _displayTextBoxSampler = new RelayCommand(param => ExecuteDisplayTextBoxSampler(), param => CanDisplayTextBoxSampler());

                return _displayTextBoxSampler;
            }
        }

        private void ExecuteDisplayTextBoxSampler()
        {
            var view = new TextBoxSamplerView();
            var viewModel = new TextBoxSamplerViewModel();
            view.DataContext = viewModel;
            view.Show();
        }

        private bool CanDisplayTextBoxSampler()
        {
            return true;
        }

        #endregion TextBox Sampler

        #region ComboBox Sampler

        private RelayCommand _displayComboBoxSampler;

        public ICommand DisplayComboBoxSamplerCommand
        {
            get
            {
                if (_displayComboBoxSampler == null)
                    _displayComboBoxSampler = new RelayCommand(param => ExecuteDisplayComboBoxSampler(), param => CanDisplayComboBoxSampler());

                return _displayComboBoxSampler;
            }
        }

        private void ExecuteDisplayComboBoxSampler()
        {
            MessageBox.Show("Display ComboBoxSampler!");
        }

        private bool CanDisplayComboBoxSampler()
        {
            return false;
        }

        #endregion ComboBox Sampler

        #region ListBox Sampler

        private RelayCommand _displayListBoxSampler;

        public ICommand DisplayListBoxSamplerCommand
        {
            get
            {
                if (_displayListBoxSampler == null)
                    _displayListBoxSampler = new RelayCommand(param => ExecuteDisplayListBoxSampler(), param => CanDisplayListBoxSampler());

                return _displayListBoxSampler;
            }
        }

        private void ExecuteDisplayListBoxSampler()
        {
            MessageBox.Show("Display ListBoxSampler!");
        }

        private bool CanDisplayListBoxSampler()
        {
            return false;
        }

        #endregion ListBox Sampler

    }
}
