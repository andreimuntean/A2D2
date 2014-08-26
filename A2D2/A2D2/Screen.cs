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

        private string decodeWav()
        {
            var message = "";
            var wav = FileManager.ReadWav(SoundRecorder.Path);
            var frequency = SpectrumAnalyzer.GetFrequency(wav);

            message = SpectrumAnalyzer.Decode(frequency);
            message = Translator.ToHuman(message);

            FileManager.Write(message, "mesaj.txt");
            
            return message;
        }

        private void displayMessage(string message, bool isError = false)
        {
            if (isError) messageTextBox.ForeColor = Color.FromArgb(255, 0, 0);
            else messageTextBox.ForeColor = Color.FromArgb(0, 0, 0);

            messageTextBox.Text = message;
        }

        private void resetMessages()
        {
            messageTextBox.Text = "";
        }

        private void buttonSay_Click(object sender, EventArgs e)
        {
            if (messageTextBox.Text != "Listening ...") resetMessages();

            foreach (var character in messageSent.Text)
            {
                if ('A' <= character && character <= 'Z') continue;
                if ('0' <= character && character <= '9') continue;
                if (character != ' ')
                {
                    displayMessage("ERROR: Only numbers, spaces and uppercase letters are permitted.", true);
                    return;
                }
            }

            var message = Translator.ToMachine(messageSent.Text);

            SoundPlayer.Speak(message);
        }

        private void buttonListen_Click(object sender, EventArgs e)
        {
            resetMessages();

            if (SoundRecorder.IsRecording)
            {
                resetMessages();
                buttonListen.Text = "Listen  ";
                SoundRecorder.Stop();
                messageReceived.Text = decodeWav();
            }
            else
            {
                displayMessage("Listening ...");
                buttonListen.Text = "Stop  ";
                SoundRecorder.Start();
            }
        }

        private void messageSent_KeyPress(object sender, KeyPressEventArgs e)
        {
            displayMessage(messageSent.Text.Length + " / 160");
        }

        private void messageSent_KeyUp(object sender, KeyEventArgs e)
        {
            displayMessage(messageSent.Text.Length + " / 160");
        }
    }
}
