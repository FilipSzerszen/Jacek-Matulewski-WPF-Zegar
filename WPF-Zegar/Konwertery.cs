using System;
using System.Globalization;
using System.Windows.Data;

namespace WPF_Zegar
{
    public enum Wskazówka { Godzinowa, Minutoowa, Sekundowa};
    public class KonwerteryKątaWskazówki : IValueConverter
    {
        public Wskazówka Wskazówka { get; set; } = Wskazówka.Godzinowa;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime dt = (DateTime)value;
            double wartość = 0;
            double kąt = 0;

            switch (Wskazówka)
            {
                case Wskazówka.Godzinowa:
                    wartość = dt.Hour;
                    if (wartość > 12) wartość -= 12;
                    wartość += dt.Minute / 60;
                    wartość = wartość * 360 / 12;
                    break;
                case Wskazówka.Minutoowa:
                    wartość = dt.Minute;
                    wartość += dt.Second/ 60;
                    wartość = wartość * 360 / 60;
                    break;
                case Wskazówka.Sekundowa:
                    wartość = dt.Second;
                    wartość = wartość * 360 / 60;
                    break;
            }
            return wartość;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
