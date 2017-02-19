using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiceCup
{
    public partial class History : ContentPage
    {
        public History(List<DiceRoll> diceLst)
        {

            InitializeComponent();
            Title = "Roll Dice - History";
            Dictionary<int, string> diceDictionary = new Dictionary<int, string>()
            {
                {1, "one.png" },
                {2, "two.png" },
                {3, "three.png" },
                {4, "four.png" },
                {5, "five.png" },
                {6, "six.png" },
            };

            foreach (var diceRoll in diceLst)
            {
                var stack = new StackLayout();
                stack.Orientation = StackOrientation.Horizontal;                
                stack.BackgroundColor = Color.FromHex("DDDDDD");
                var timeLabel = new Label
                {
                    Margin = 10,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    Text = diceRoll.Time.TimeOfDay.ToString()
                };
                stack.Children.Add(timeLabel);

                var dice1 = new Image
                {
                    Margin = 4,
                    Source = diceDictionary[diceRoll.Dice1],
                    WidthRequest = 30,
                    HeightRequest = 30
                };
                stack.Children.Add(dice1);

                var dice2 = new Image
                {
                    Margin = 4,
                    Source = diceDictionary[diceRoll.Dice2],
                    WidthRequest = 30,
                    HeightRequest = 30
                };
                stack.Children.Add(dice2);

                HistoryStack.Children.Add(stack);
            }
        }

        private void ClearButton_OnClicked(object sender, EventArgs e)
        {
            MainPage.DiceRollList.Clear();
            HistoryStack.Children.Clear();
        }
    }
}
