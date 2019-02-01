using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MouseShaker
{
    public partial class Form1 : Form
    {

        // We need to use unmanaged code
        [DllImport("user32.dll")]
        // GetCursorPos() makes everything possible
        static extern bool GetCursorPos(ref Point lpPoint);

        static int shaker = 0;
        static int x = 0;
        static int y = 0;

        static string direction = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 10;
            timer2.Enabled = true;
            timer2.Interval = 1000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // New point that will be updated by the function with the current coordinates
            Point currentCoordinates = new Point();

            // Call the function and pass the Point
            GetCursorPos(ref currentCoordinates);

            // Now after calling the function, defPnt contains the coordinates which we can read
            lblCoordX.Text = "X = " + currentCoordinates.X.ToString();
            lblCoordY.Text = "Y = " + currentCoordinates.Y.ToString();

            //if (currentCoordinates.X == x) { direction = "still"; }

            if (currentCoordinates.X < x) { direction = "left"; }
            if (currentCoordinates.X > x) { direction = "right"; }

            x = currentCoordinates.X;

            lblMessage.Text = "Mouse Pointer = " + direction;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (direction != direction) { shaker += 1; }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            //Cursor cur = new Cursor(Properties.Resources.extralargearrow.Handel);
            //this.Cursor = cur;
        }

    }
}
