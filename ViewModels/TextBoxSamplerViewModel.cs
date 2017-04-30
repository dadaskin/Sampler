// Things to do:
// 1. On last TextBox control make red-box conform to width 
// 2. If a child window is closed, re-enable corresponding Button in MainWindow.
// 3. Add ExtendedTextBox class and show off other behaviors

using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using TextBoxSampler.Framework;

namespace TextBoxSampler.ViewModels
{
    public class TextBoxSamplerViewModel :ValidationModelBase 
    {
        #region Fields

        private string _minimalValidation;
        private string _validationWithErrors;
        private string _validationWithIcon;
        private string _validationWithToolTip;
        private string _validationMessagesBelow;
        private double _etb1;

        #endregion Fields

        #region Properties

        public string MinimalStyling { get; set; }

        public string MinimalValidation
        {
            get { return _minimalValidation; }
            set
            {
                _minimalValidation = value;

                // How efficient is this?  My intent was to get both a reference to the property and it's value to the called method
                // without using a stirng literal.
                // I'm converting the property to it's name and then getting the corresponding PropertyInfo object here.
                // I pass the PropertyInfo object, then the called method converts the PropertyInfo object into the 
                // property and it's value.
                // Other ways of doing this can be found at http://stackoverflow.com/questions/1402803/passing-properties-by-reference-in-c-sharp
                Validate(GetType().GetProperty(GetPropertyName(() => MinimalValidation)));
            }
        }

        public string ValidationWithErrors
        {
            get { return _validationWithErrors; }
            set
            {
                _validationWithErrors = value;
                Validate(GetType().GetProperty(GetPropertyName(() => ValidationWithErrors)));
            }
        }

        public string ValidationWithIcon
        {
            get { return _validationWithIcon; }
            set
            {
                _validationWithIcon = value;
                Validate(GetType().GetProperty(GetPropertyName(() => ValidationWithIcon)));
            }
        }

        public string ValidationWithToolTip
        {
            get { return _validationWithToolTip; }
            set
            {
                _validationWithToolTip = value;
                Validate(GetType().GetProperty(GetPropertyName(() => ValidationWithToolTip)));
            }
        }

        public string ValidationMessagesBelow
        {
            get { return _validationMessagesBelow; }
            set
            {
                _validationMessagesBelow = value;
                Validate(GetType().GetProperty(GetPropertyName(() => ValidationMessagesBelow)));
            }
        }

        public double Etb1
        {
            get { return _etb1; }
            set { _etb1 = value; }
        }

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

        public static string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
                return string.Empty;

            var expression = (propertyExpression.Body as MemberExpression);
            return expression == null ? string.Empty : expression.Member.Name;
        }

        // Make these strings into resources.
        private const string ErrorEmpty = "Text must have 3 or more characters.";
        private const string ErrorNoX = "Text must not contain 'x'.";
        private const string ErrorTooLong = "Text must have 7 or fewer characters.";

        // Note: All Validation* methods assume that the value of the property is of type String.
        private void Validate(PropertyInfo pi)
        {
            if (pi == null)
                return;

            var propertyName = pi.Name;
            var propertyValueObject = pi.GetValue(this);
            if (propertyValueObject == null)
                return;

            var propertyValue = (string)propertyValueObject;
            if (string.IsNullOrEmpty(propertyValue))
                return;

            ValidateMinLength(propertyName,propertyValue);
            ValidateMaxLength(propertyName, propertyValue);
            ValidateNoX(propertyName, propertyValue);
        }

        private void ValidateMinLength(string propertyName, string propertyValue)
        {
            if (propertyValue.Length < 3)
                AddError(propertyName, ErrorEmpty);
            else
                RemoveError(propertyName, ErrorEmpty);
        }

        private void ValidateMaxLength(string propertyName, string propertyValue)
        {
            if (propertyValue.Length > 7)
                AddError(propertyName, ErrorTooLong);
            else
                RemoveError(propertyName, ErrorTooLong);
        }

        private void ValidateNoX(string propertyName, string propertyValue)
        {
            if (propertyValue.Contains("x"))
                AddError(propertyName, ErrorNoX);
            else
                RemoveError(propertyName, ErrorNoX);
        }

        #endregion Validation
    }
}
