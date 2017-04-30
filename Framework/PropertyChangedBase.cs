//
// Copied from Caliburn Micro
//

using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace TextBoxSampler.Framework
{
    /// <summary>
    /// A base class that implements the infrastructure for property change notification and automatically performs UI thread marshalling.
    /// </summary>
    public class PropertyChangedBase : INotifyPropertyChangedEx
    {
        /// <summary>
        /// Creates an instance of PropertyChangedBase.
        /// </summary>
        public PropertyChangedBase()
        {
            IsNotifying = true;
        }

        /// <summary>
        /// Occurs when a property value changes
        /// </summary>
        public virtual event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Enables/Disables property change notification.
        /// Virtualized in order to help with document oriened view models.
        /// </summary>
        public virtual bool IsNotifying { get; set; }

        /// <summary>
        ///  Raises a change notification indicating that all bindings should be refreshed.
        /// </summary>
        public void Refresh()
        {
            NotifyOfPropertyChange(string.Empty);
        }

        /// <summary>
        /// Notifies subscribers of the property change.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public void NotifyOfPropertyChange(string propertyName)
        {
            if (IsNotifying && PropertyChanged != null)
            {
                Execute.OnUIThread(() => OnPropertyChanged(new PropertyChangedEventArgs(propertyName)));
            }
        }

        /// <summary>
        /// Notifies subscribers of the property change.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="property">The property expression.</param>
        public void NotifyOfPropertyChange<TProperty>(Expression<Func<TProperty>> property)
        {
            NotifyOfPropertyChange(property.GetMemberInfo().Name);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

    }
}
