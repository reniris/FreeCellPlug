using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Xaml;

namespace FreeCellPlug.Views.Converter
{
    public class ResourceKeyToBrushConverter : ValueConverterBase<string, Brush>
    {
        private FrameworkElement element = null;

        public override Brush Convert(string key, object parameter, CultureInfo culture)
        {
            var b = element?.TryFindResource(key) ?? Application.Current.TryFindResource(key);

            return (Brush)b;
        }

        public override string ConvertBack(Brush value, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (!(serviceProvider.GetService(typeof(IRootObjectProvider)) is IRootObjectProvider rootObjectProvider))
                return this;

            element = rootObjectProvider.RootObject as FrameworkElement;

            return this;
        }
    }
}
