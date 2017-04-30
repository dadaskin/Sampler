//
// Copied from Caliburn Micro
//

using System.ComponentModel;

namespace TextBoxSampler.Framework
{
    public interface INotifyPropertyChangedEx : INotifyPropertyChanged
    {
        /// <summary>
        /// Enables/Disables property change notification
        /// </summary>
        bool IsNotifying { get; set; }

        /// <summary>
        /// Notifies subscribers of the property change
        /// </summary>
        /// <param name="propertyName"></param>
        void NotifyOfPropertyChange(string propertyName);

        /// <summary>
        /// Raises a change notification indicating that all bindings should be refreshed.
        /// </summary>
        void Refresh();

    }

}
