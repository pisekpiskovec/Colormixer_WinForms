namespace Colormixer_WinForms
{
    public partial class Form1 : Form
    {
        

        int maxRGB;
        decimal avrR, avrG, avrB;
        int clr1R, clr1G, clr1B;
        int clr2R, clr2G, clr2B;
        Color clr1 = Color.Black, clr2 = Color.Black;

        public Form1()
        {
            InitializeComponent();
            object sender = this; EventArgs e = EventArgs.Empty;
            numericUpDown_ValueChanged(sender, e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            Color tmp = colorDialog.Color;
            clr1 = tmp;
            pictureBox1.BackColor = tmp;
            clr1R = tmp.R; clr1G = tmp.G; clr1B = tmp.B;

            numericUpDown_ValueChanged(sender, e);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            Color tmp = colorDialog.Color;
            clr2 = tmp;
            pictureBox3.BackColor = tmp;
            clr2R = tmp.R; clr2G = tmp.G; clr2B = tmp.B;

            numericUpDown_ValueChanged(sender, e);
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if(numericUpDown1.Value == 0 && numericUpDown2.Value == 0 ) { pictureBox2.BackColor = Color.FromKnownColor(KnownColor.Control); textBox1.Text = string.Empty; return; }

            maxRGB = ((int)numericUpDown1.Value * 255) + ((int)numericUpDown2.Value * 255);

            avrR = (clr1R * numericUpDown1.Value) + (clr2R * numericUpDown2.Value);
            avrG = (clr1G * numericUpDown1.Value) + (clr2G * numericUpDown2.Value);
            avrB = (clr1B * numericUpDown1.Value) + (clr2B * numericUpDown2.Value);


            avrR *= 255;
            avrG *= 255;
            avrB *= 255;

            avrR /= maxRGB;
            avrG /= maxRGB;
            avrB /= maxRGB;

            avrR = Math.Ceiling(avrR); avrG = Math.Ceiling(avrG); avrB = Math.Ceiling(avrB);

            Color res = Color.FromArgb(255, (int)avrR, (int)avrG, (int)avrB);
            pictureBox2.BackColor = res;
            textBox1.Text = res.ToHex();
        }
    }
    public static class HexColorExtensions { public static string ToHex(this Color c) => $"#{c.R:X2}{c.G:X2}{c.B:X2}"; }
}
