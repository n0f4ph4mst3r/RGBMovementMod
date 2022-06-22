using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OverleyEnhanced
{
    public class SourceWrapper : ImageWrapper
    {
        double m_avg; //средняя яркость
        double m_dev; //среднеквадратичное отклонение
        public SourceWrapper(in Bitmap src, in PerceptionCoffs coffs) 
        {
            Update(src, coffs);
        }
        public void Update(in Bitmap src, in PerceptionCoffs coffs)
        {
            this.coffs = coffs;
            bit = src;
            Update();
        }
        override public void Update()
        {
            base.Update();
            //читаем битмап
            BitmapData databit = bit.LockBits(new Rectangle(0, 0, bit.Width, bit.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            IntPtr pointer = databit.Scan0;
            Marshal.Copy(pointer, bytes, 0, bytes.Length);
            bit.UnlockBits(databit);
            //устанавливаем шкалу яркости
            for (int i = 0; i < y.Length; ++i)
            {
                y[i] = Convert.ToByte(Math.Round(coffs.k1 * bytes[i] + coffs.k2 * bytes[i + 1] + coffs.k3 * bytes[i + 2]));
            }
            SetFrequencys();
            //находим среднюю яркость
            m_avg = 0;
            for (int i = 0; i < 256; i++)
            {
                m_avg += i * frequencyList[i];
            }
            //находим среднеквадратичное отклонение
            m_dev = 0;
            for (int i = 0; i < 256; i++)
            {
                m_dev += Math.Pow(i - m_avg, 2) * frequencyList[i];
            }
            m_dev = Math.Sqrt(m_dev);
        }
        public double Avg
        {
            get
            {
                return m_avg;
            }
        }
        public double Dev
        {
            get
            {
                return m_dev;
            }
        }
    }
}
