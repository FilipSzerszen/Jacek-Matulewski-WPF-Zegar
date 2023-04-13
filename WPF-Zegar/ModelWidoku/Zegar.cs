using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WPF_Zegar.ModelWidoku
{
    public class Zegar : ObservedObject
    {
        private DateTime poprzedniCzas = DateTime.Now;

        public DateTime AktualnyCzas
        {
            get
            {
                return DateTime.Now;
            }
        }

        private const int okresOdświeżaniaWidoku = 250;
        public Zegar()
        {
            DispatcherTimer timerOdświeżaniaWidoku = new DispatcherTimer();
            timerOdświeżaniaWidoku.Tick +=
                (sender, e) =>
                {
                    if (AktualnyCzas.Second != poprzedniCzas.Second)
                    {
                        poprzedniCzas = AktualnyCzas;
                        OnPropertyChanged(nameof(AktualnyCzas));
                    }
                };
            timerOdświeżaniaWidoku.Interval = TimeSpan.FromMilliseconds(okresOdświeżaniaWidoku);
            timerOdświeżaniaWidoku.Start();
        }
    }
}
