using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DiceCup
{
    public partial class MainPage : ContentPage
    {
        public static List<DiceRoll> DiceRollList = new List<DiceRoll>();
        public MainPage()
        {
            InitializeComponent();
            Title = "Roll Dice";
            RollPicker.SelectedIndex = 0;
        }

        async void HistoryButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new History(DiceRollList));
        }

        private void RollButton_OnClicked(object sender, EventArgs e)
        {
            Random dice = new Random();
            var rolls = RollPicker.SelectedIndex;

            for (int i = 0; i < rolls + 1; i++)
            {
                var dice1 = dice.Next(1, 6);
                var dice2 = dice.Next(1, 6);
                var time = DateTime.Now;
                var diceRoll = new DiceRoll()
                {
                    Dice1 = dice1,
                    Dice2 = dice2,
                    Time = time
                };
                DiceRollList.Add(diceRoll);
            }

        }
    }
}
