using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            Text = "About";
            AddLabel(new Point(170, 8), new Size(180, 80), 
                "This project is designed as the final part" + 
                "of the course software engineering. Work"   +
                "performed by students 3 courses of 316"     +
                "groups: Uimonen Arvi and Ilin Evgeniy");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Label of label
        private void AddLabel(Point location, Size area, string str)
        {
            Label label = new Label();
            label.Text = str;
            label.Location = location;
            label.Size = area;
            Controls.Add(label);

        }
        //private void AddLinkLabel(Point location, Size area, string str)
        //{
        //    LinkLabel label = new LinkLabel();
        //    label.Text = str;
        //    label.Location = location;
        //    label.Size = area;
        //    Controls.Add(label);
        //}

    }
}
