using System;
using System.ComponentModel;
using System.Collections.Generic;


namespace TextBoxSampler.Framework
{
    public class ValidationModelBase : PropertyChangedBase, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<String>> _errors = new Dictionary<string, List<string>>();


        #region INotifyDataErrorInfo Implenentation

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) || !_errors.ContainsKey(propertyName))
                return null;

            return _errors[propertyName];
        }

        public bool HasErrors
        {
            get { return _errors.Count > 0; }
        }

        #endregion INotifyDataErrorInfo Implenentation

        #region Public Methods

        public void AddError(string propertyName, string error)
        {
            if (!_errors.ContainsKey(propertyName))
                _errors[propertyName] = new List<string>();

            if (!_errors[propertyName].Contains(error))
            {
                _errors[propertyName].Add(error);
                RaiseErrorsChanged(propertyName);
            }
        }


        public void RemoveError(string propertyName, string error)
        {
            if (_errors.ContainsKey(propertyName) && _errors[propertyName].Contains(error))
            {
                _errors[propertyName].Remove(error);

                if (_errors[propertyName].Count == 0)
                    _errors.Remove(propertyName);

                RaiseErrorsChanged(propertyName);
            }
        }

        public void RaiseErrorsChanged(string propertyName)
        {
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }

        #endregion Public Methods
    }
}
