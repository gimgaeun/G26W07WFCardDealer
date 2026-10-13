using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace G26W07WFCardDealer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OnDeal(object sender, EventArgs e)
        {
            string[] suits = ["spades", "hearts", "diamonds", "clubs"];
            string[] values = ["ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king"];

            PictureBox[] pictureBoxes = [ Card1, Card2, Card3, Card4, Card5 ];

            Random random = new Random();

            //HashSet은 중복된 값을 허용하지 않음
            HashSet<int> selectedCards = new HashSet<int>();

            while (selectedCards.Count < 5)
            {
                int card = random.Next(suits.Length * values.Length);
                selectedCards.Add(card);
            }

            int index = 0;

            foreach (int card in selectedCards)
            {
                string suit = suits[card / values.Length];
                string value = values[card % values.Length];

                if (value is "jack" or "queen" or "king")
                {
                    suit += "2";
                }

                string name = $"{value}_of_{suit}";

                pictureBoxes[index].Image = Properties.Resources.ResourceManager
                .GetObject(name) as Image
                ?? Properties.Resources.red_joker;

                index++;
            }

        }
    }
}
