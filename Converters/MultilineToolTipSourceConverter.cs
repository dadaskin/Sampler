using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace TextBoxSampler.Converters
{
    public class MultilineToolTipSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var errors = value as ReadOnlyCollection<ValidationError>;
            if (errors != null)
            {
                var run = string.Empty;

                if (errors.Count == 1)
                    return errors[0].ErrorContent;

                // For multiple errors, prefix each with a dash.
                for (var i = 0; i < errors.Count; i++)
                {
                    if (i == 0)
                        run += "- " + errors[i].ErrorContent;
                    else
                        run += Environment.NewLine + "- " + errors[i].ErrorContent;
                }
                return run;
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
