using System;
using System.Drawing;
using System.Windows.Forms;

namespace MouseShaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            timer2.Enabled = !timer2.Enabled;

            switch (timer2.Enabled)
            {
                case true:
                    btnChange.Text = $@"Stop";
                    btnChange.ForeColor = Color.Red;
                    lblMessage.Text = $@"Mouse is Shaking";
                    break;
                case false:
                    btnChange.Text = $@"Start";
                    btnChange.ForeColor = Color.Green;
                    lblMessage.Text = $@"Mouse is NOT Shaking";
                    break;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            // New point that will be updated by the function with the current coordinates
            Win32Cursor.Point currentCoordinates = new Win32Cursor.Point();

            // Call the function and pass the Point
            Win32Cursor.GetCursorPosition(ref currentCoordinates);

            // Now after calling the function, defPnt contains the coordinates which we can read
            lblCoordX.Text = $@"X = {currentCoordinates.x}";
            lblCoordY.Text = $@"Y = {currentCoordinates.y}";
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            Win32Cursor.MoveCursor(GetRandomNumber(), GetRandomNumber(), this.Handle);
        }

        private int GetRandomNumber()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            return random.Next(-5, 5);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}