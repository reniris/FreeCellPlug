using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace FreeCellPlug.Views.Converter
{
    // SからTへの変換
    public abstract class ValueConverterBase<S, T> : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
            {
                S t_val => Convert(t_val, parameter, culture),
                IEnumerable<S> t_arr => t_arr.Select(t => Convert(t, parameter, culture)),
                _ => null,
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
            {
                T u_val => ConvertBack(u_val, parameter, culture),
                IEnumerable<T> u_arr => u_arr.Select(u => ConvertBack(u, parameter, culture)),
                _ => null,
            };
        }

        public override object ProvideValue(IServiceProvider serviceProvider) => this;

        public abstract T Convert(S value, object parameter, CultureInfo culture);
        public abstract S ConvertBack(T value, object parameter, CultureInfo culture);
    }

    public abstract class MultiValueConverterBase<S1, S2, T> : IMultiValueConverter
    {
        public virtual object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2)
                return Binding.DoNothing;

            if (values.Any(v => v == DependencyProperty.UnsetValue) == true)
                return null;

            var val1 = (S1)values[0];
            var val2 = (S2)values[1];

            return Convert(val1, val2, parameter, culture);
        }

        public virtual object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            var (s1, s2) = ConvertBack((T)value, parameter, culture);
            var ret = new object[] { s1, s2 };
            return ret;
        }

        public abstract T Convert(S1 val1, S2 val2, object parameter, CultureInfo culture);
        public abstract (S1 s1, S2 s2) ConvertBack(T value, object parameter, CultureInfo culture);
    }
}
