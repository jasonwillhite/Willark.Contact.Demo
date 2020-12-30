using System;
using System.Windows.Input;
using Willark.Contact.Demo.Common;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Willark.Contact.Demo.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://xamarin.com"));
            FlipTheCard = new Command(FlipTheCardCommand);
        }

        private async void FlipTheCardCommand(object self)
        {
            Frame frame = self as Frame;
            if (frame == null) { return; }

            await FlipCardHelper.AnimateCardDrawing(frame, frame.Content as Image);

            
        }

        public ICommand OpenWebCommand { get; }

        public ICommand FlipTheCard { get; }
    }
}