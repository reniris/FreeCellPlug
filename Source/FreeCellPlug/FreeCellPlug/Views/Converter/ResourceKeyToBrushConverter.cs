using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace FreeCellPlug.Views.Converter
{
    public class ResourceKeyToBrushConverter : MultiValueConverterBase<FrameworkElement, string, Brush>
    {
        public override Brush Convert(FrameworkElement res, string key, object parameter, CultureInfo culture)
        {
            var b = (Brush)res?.TryFindResource(key);
            return b;
        }

        public override (FrameworkElement s1, string s2) ConvertBack(Brush value, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
