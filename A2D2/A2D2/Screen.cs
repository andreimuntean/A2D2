using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A2D2
{
    public partial class Screen : Form
    {
        public Screen()
        {
            InitializeComponent();
        }
        
        private void button0_Click(object sender, EventArgs e)
        {
            SoundPlayer.PlayLowPitch();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SoundPlayer.PlayMediumPitch();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SoundPlayer.PlayHighPitch();
        }

        private void buttonSay_Click(object sender, EventArgs e)
        {
            var yolo = Translator.ToMachine(messageSent.Text);
            SoundPlayer.Speak(yolo);
        }
    }
}
