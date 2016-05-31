using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public partial class Rules : Form
    {
        public Rules()
        {
            InitializeComponent();
            AddLabel(new Point(170, 8), new Size(225, 500),
                "In most games of checkers, there are two players." +
                "The players are at opposite ends of the board. " +
                "One player has dark pieces, and one player has light pieces." +
                "They take turns moving their pieces. Players move their pieces" +
                "diagonally from one square to another square. When a player jumps" +
                "over their opponent's (the other player's) piece, you take that piece" +
                "from the board. If you can take a piece, then you must take a piece.");
        }
        private void Rules_Load(object sender, EventArgs e)
        {
            Text = "Rules";
        }

        private void AddLabel(Point location, Size area, string str)
        {
            Label label = new Label();
            label.Text = str;
            label.Location = location;
            label.Size = area;
            Controls.Add(label);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
