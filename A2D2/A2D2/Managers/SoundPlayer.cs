using System;
using System.IO;
using System.Windows.Forms;

namespace A2D2
{
    static class SoundPlayer
    {
        public static int BeepDuration { get; private set; }
        private static Timer timer;
        private static string currentMessage;

        static SoundPlayer()
        {
            BeepDuration = 80;
            timer = new Timer();
            timer.Interval = BeepDuration + 5;
            timer.Tick += TimerEvent;
        }

        // Courtesy of StackOverflow.
        public static void Beep(UInt16 frequency, UInt16 volume = 65335)
        {
            var stream = new MemoryStream();
            var writer = new BinaryWriter(stream);

            const double TAU = 2 * Math.PI;
            int formatChunkSize = 16;
            int headerSize = 8;
            short formatType = 1;
            short tracks = 1;
            int samplesPerSecond = 44100;
            short bitsPerSample = 16;
            short frameSize = (short)(tracks * ((bitsPerSample + 7) / 8));
            int bytesPerSecond = samplesPerSecond * frameSize;
            int waveSize = 4;
            int samples = (int)((decimal)samplesPerSecond * BeepDuration / 1000);
            int dataChunkSize = samples * frameSize;
            int fileSize = waveSize + headerSize + formatChunkSize + headerSize + dataChunkSize;
            
            // var encoding = new System.Text.UTF8Encoding();
            
            writer.Write(0x46464952); // = encoding.GetBytes("RIFF")
            writer.Write(fileSize);
            writer.Write(0x45564157); // = encoding.GetBytes("WAVE")
            writer.Write(0x20746D66); // = encoding.GetBytes("fmt ")
            writer.Write(formatChunkSize);
            writer.Write(formatType);
            writer.Write(tracks);
            writer.Write(samplesPerSecond);
            writer.Write(bytesPerSecond);
            writer.Write(frameSize);
            writer.Write(bitsPerSample);
            writer.Write(0x61746164); // = encoding.GetBytes("data")
            writer.Write(dataChunkSize);
            {
                double theta = frequency * TAU / (double)samplesPerSecond;
                // 'volume' is UInt16 with range 0 thru Uint16.MaxValue (= 65535)
                // we need 'amp' to have the range of 0 thru Int16.MaxValue (= 32767)
                double amp = volume >> 2; // so we simply set amp = volume / 2
                for (int step = 0; step < samples; step++)
                {
                    short s = (short)(amp * Math.Sin(theta * (double)step));
                    writer.Write(s);
                }
            }

            stream.Seek(0, SeekOrigin.Begin);
            new System.Media.SoundPlayer(stream).Play();
            
            writer.Close();
            stream.Close();
        }

        public static void PlayHighPitch()
        {
            Beep(941);
            Beep(1633);
        }

        public static void PlayMediumPitch()
        {
            Beep(852);
            Beep(1336);
        }

        public static void PlayLowPitch()
        {
            Beep(679);
            Beep(1209);
        }

        public static void Speak(char character)
        {
            switch (character)
            {
                case '0': PlayLowPitch(); break;
                case '1': PlayHighPitch(); break;
                case '2': PlayMediumPitch(); break;
            }
        }

        public static void Speak(string message)
        {
            currentMessage = message;
            timer.Start();
        }

        #region Events
        private static void TimerEvent(object sender, EventArgs e)
        {
            if (currentMessage.Length > 0)
            {
                Speak(currentMessage[0]);
                currentMessage = currentMessage.Substring(1, currentMessage.Length - 1);
            }
            else
            {
                timer.Stop();
            }
        }
        #endregion
    }
}
