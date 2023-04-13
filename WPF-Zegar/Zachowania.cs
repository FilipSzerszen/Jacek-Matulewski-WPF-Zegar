using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_Zegar
{
    public class PrzesuwanieOkna : Behavior<Window>
    {
        protected override void OnAttached()
        {
            Window window = this.AssociatedObject;
            if (window != null)
            {
                window.MouseDown += window_MouseDown;
                window.MouseMove += window_MouseMove;
                window.MouseUp += window_MouseUp;
            }
        }

        private bool TrwaPrzesuwanie = false;
        Point początkowaPozycjaKursora;

        private void window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Window window = (Window)sender;
            if(!TrwaPrzesuwanie && e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                TrwaPrzesuwanie = true;
                początkowaPozycjaKursora = e.GetPosition(window);
            }
        }
        private void window_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Window window = (Window)sender;
            if (TrwaPrzesuwanie)
            {
                Point pozycjaKursora = e.GetPosition(window);
                Vector przesunięcie = pozycjaKursora - początkowaPozycjaKursora;
                window.Left += przesunięcie.X;
                window.Top += przesunięcie.Y;
            }
        }
        private void window_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Window window = (Window)sender;
            if(TrwaPrzesuwanie && e.LeftButton == System.Windows.Input.MouseButtonState.Released)
            {
                TrwaPrzesuwanie = false;
            }
        }
    }
}
