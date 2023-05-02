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
        public SourceWrapper(Bitmap src, PerceptionCoffs coffs) 
        {
            Update(src, coffs);
        }
        public void Update(Bitmap src, PerceptionCoffs coffs)
        {
            m_coffs = coffs;
            m_bit = src;
            Update();
        }
        override public void Update()
        {
            base.Update();
            //читаем битмап
            BitmapData databit = m_bit.LockBits(new Rectangle(0, 0, m_bit.Width, m_bit.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            IntPtr pointer = databit.Scan0;
            Marshal.Copy(pointer, m_bytes, 0, m_bytes.Length);
            m_bit.UnlockBits(databit);
            //устанавливаем шкалу яркости
            for (int i = 0, j = 0; i < m_bytes.Length; i += 3, j++)
            {
                m_y[j] = Convert.ToByte(Math.Round(m_coffs.k1 * m_bytes[i] + m_coffs.k2 * m_bytes[i + 1] + m_coffs.k3 * m_bytes[i + 2]));
            }
            SetFrequencys();
            //находим среднюю яркость
            m_avg = 0;
            for (int i = 0; i < 256; i++)
            {
                m_avg += i * m_frequencyList[i];
            }
            //находим среднеквадратичное отклонение
            m_dev = 0;
            for (int i = 0; i < 256; i++)
            {
                m_dev += Math.Pow(i - m_avg, 2) * m_frequencyList[i];
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
