using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Willark.Contact.Demo.Common
{
    public static class FlipCardHelper
    {
        public static async Task AnimateCardDrawing(Frame card, Image image)
        {
            try
            {
                
                Random rand = new Random();
                card.BackgroundColor = new Color(rand.NextDouble(), rand.NextDouble(), rand.NextDouble());
                //await card.TranslateTo(100, 0, 400);
                await card.RotateYTo(-90, 200);
                card.RotationY = -270;

                // Change UI here, to reflect 'back' of the card
                //image.Source = (card.Content as Image).Source = image.Source;
                (card.Content as Grid).Children[0].IsVisible = false;
                (card.Content as Grid).Children[1].IsVisible = true;

                //await card.RotateYTo(-360, 200);
                //await card.TranslateTo(0, 0, 220);
                card.RotationY = 0;
                card.ForceLayout();
                
            }
            catch(Exception ex)
            {

            }

        }
    }
}
