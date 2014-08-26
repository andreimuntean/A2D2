using System;

namespace A2D2
{
    static class SpectrumAnalyzer
    {
        // Converts two bytes to one double in the range of -1 to 1.
        private static double BytesToDouble(byte firstByte, byte secondByte)
        {
            // Converts two bytes to one short (little endian);
            short s = (short)((secondByte << 8) | firstByte);
            return s / 32768.0;
        }

        /// <summary>
        /// Gets the number of significant bytes.
        /// </summary>
        /// <param name="n">Number.</param>
        /// <returns>Amount of minimal bits required to store the number.</returns>
        private static int Log2(int n)
        {
            int i = 0;
            while (n > 0)
            {
                ++i; n >>= 1;
            }
            return i;
        }

        /// <summary>
        /// Reverses bits in the number.
        /// </summary>
        /// <param name="n">Number.</param>
        /// <param name="bitsCount">Significant bits in the number.</param>
        /// <returns>Reversed binary number.</returns>
        private static int ReverseBits(int n, int bitsCount)
        {
            int reversed = 0;
            for (int i = 0; i < bitsCount; i++)
            {
                int nextBit = n & 1;
                n >>= 1;

                reversed <<= 1;
                reversed |= nextBit;
            }
            return reversed;
        }

        /// <summary>
        /// Checks if number is power of 2.
        /// </summary>
        /// <param name="n">number</param>
        /// <returns>True if n=2^k and k is a positive integer.</returns>
        private static bool IsPowerOfTwo(int n)
        {
            return n > 1 && (n & (n - 1)) == 0;
        }

        /// <summary>
        /// Gets the voltage data of a WAV file.
        /// </summary>
        /// <param name="wav"></param>
        /// <returns></returns>
        public static double[] CalculateVoltageData(byte[] wav)
        {
            // Get past all the other sub chunks to get to the data subchunk:
            int pos = 12; // First Subchunk ID from 12 to 16

            // Keep iterating until we find the data chunk (i.e. 64 61 74 61 ...... (i.e. 100 97 116 97 in decimal))
            while (!(wav[pos] == 100 && wav[pos + 1] == 97 && wav[pos + 2] == 116 && wav[pos + 3] == 97))
            {
                pos += 4;
                int chunkSize = wav[pos] + wav[pos + 1] * 256 + wav[pos + 2] * 65536 + wav[pos + 3] * 16777216;
                pos += 4 + chunkSize;
            }
            pos += 8;

            // Pos is now positioned to start of actual sound data.
            int samples = (wav.Length - pos) / 2;

            // Allocate memory
            var result = new double[samples];

            // Write to double array:
            int i = 0;
            while (pos < wav.Length - 1)
            {
                result[i] = BytesToDouble(wav[pos], wav[pos + 1]);
                pos += 2;
                i++;
            }

            return result;
        }

        /// <summary>
        /// Calculates FFT using Cooley-Tukey FFT algorithm.
        /// </summary>
        /// <param name="voltageData">Input data.</param>
        /// <returns>Spectrogram of the data.</returns>
        /// <remarks>
        /// If amount of data items not equal a power of 2, then algorithm
        /// automatically pads with 0s to the lowest amount of power of 2.
        /// </remarks>
        public static double[] CalculateFFT(double[] voltageData)
        {
            int length;
            int bitsInLength;
            if (IsPowerOfTwo(voltageData.Length))
            {
                length = voltageData.Length;
                bitsInLength = Log2(length) - 1;
            }
            else
            {
                bitsInLength = Log2(voltageData.Length);
                length = 1 << bitsInLength;
            }

            // Bit reversal.
            ComplexNumber[] data = new ComplexNumber[length];
            for (int i = 0; i < voltageData.Length; i++)
            {
                int j = ReverseBits(i, bitsInLength);
                data[j] = new ComplexNumber(voltageData[i]);
            }

            // Cooley-Tukey. 
            for (int i = 0; i < bitsInLength; i++)
            {
                int m = 1 << i;
                int n = m * 2;
                double alpha = -(2 * Math.PI / n);

                for (int k = 0; k < m; k++)
                {
                    // e^(-2*pi/N*k) wat is lyf even
                    ComplexNumber oddPartMultiplier = new ComplexNumber(0, alpha * k).PoweredE();

                    for (int j = k; j < length; j += n)
                    {
                        ComplexNumber evenPart = data[j];
                        ComplexNumber oddPart = oddPartMultiplier * data[j + m];
                        data[j] = evenPart + oddPart;
                        data[j + m] = evenPart - oddPart;
                    }
                }
            }

            // Calculate spectrogram.
            double[] spectrogram = new double[length];
            for (int i = 0; i < spectrogram.Length; i++)
            {
                spectrogram[i] = data[i].AbsPower2();
            }
            return spectrogram;
        }

        public static double[] CalculatePitch(double[] frequency)
        {
            var pitch = new double[frequency.Length];

            for (var i = 0; i < frequency.Length; ++i)
            {
                pitch[i] = 69 + 12 * Math.Log(frequency[i] / 440, 2);
            }

            return pitch;
        }

        // This method is the reason why we can't have nice things.
        public static double[] GetFrequency(byte[] wav)
        {
            var voltageData = CalculateVoltageData(wav);
            return CalculateFFT(voltageData);
        }

        public static string Decode(double[] frequency)
        {
            var message = "";
            var lowPitch = SoundPlayer.LowPitch;
            var mediumPitch = SoundPlayer.MediumPitch;
            var highPitch = SoundPlayer.HighPitch;
            var sampleSize = 275;

            for (var i = 0; i < frequency.Length; i += sampleSize)
            {
                var average = 0.0;

                for (var j = i; j < i + sampleSize && j < frequency.Length; ++j)
                {
                    average += frequency[j] / 8;
                }

                if (IsFrequencySimilar(average, lowPitch))
                {
                    message += '0';
                }
                else if (IsFrequencySimilar(average, mediumPitch))
                {
                    message += '2';
                }
                else if (IsFrequencySimilar(average, highPitch))
                {
                    message += '1';
                }
            }

            return message;
        }

        public static bool IsFrequencySimilar(double a, double b, double errorMargin = 50)
        {
            if (Math.Abs(a - b) <= errorMargin)
                return true;
            return false;
        }
    }
}
