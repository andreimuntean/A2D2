using System.Runtime.InteropServices;

namespace A2D2
{
    public static class SoundRecorder
    {
        public static bool IsRecording { get; set; }
        public static string Path { get { return "message.wav"; } }

        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);

        public static void Start()
        {
            if (IsRecording == false)
            {
                IsRecording = true;
                mciSendString("open new Type waveaudio Alias recsound", "", 0, 0);
                mciSendString("record recsound", "", 0, 0);
            }
        }

        public static void Stop()
        {
            if (IsRecording)
            {
                mciSendString("save recsound " + Path, "", 0, 0);
                mciSendString("close recsound ", "", 0, 0);
                IsRecording = false;
            }
        }
    }
}
