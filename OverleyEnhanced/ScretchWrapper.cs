using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace OverleyEnhanced
{
    public class ScretchWrapper : EnhancedImage
    {
        double m_q = 0; //коэффициент Q
        byte[] m_z; //промежуточная шкала яркости
        double m_avg; //средняя яркость
        double m_dev; //среднеквадратичное отклонение
        public ScretchWrapper(SourceWrapper src) : base(src) {
            Update();
        }
        override public void Update()
        {
            double[] u = new double[256];
            double[] d = new double[256];
            m_z = new byte[256];
            double V;
            u[0] = 0;
            d[0] = 0.5 + m_q * m_source.FrequencyScale[0] * 255;
            for (int i = 1; i < 256; i++)
            {
                d[i] = 0.5 + m_q * m_source.FrequencyScale[i] * 255;
                u[i] = u[i - 1] + d[i - 1] + d[i];
            }
            V = 255 / u[255];
            m_z[255] = 255;
            for (int i = 0; i < 255; i++)
            {
                m_z[i] = Convert.ToByte(Math.Abs(Math.Round(V * u[i]))); //итоговая шкала яркости
            }
            base.Update();
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
        override protected byte GetBright(byte bright)
        {
            return m_z[Convert.ToInt32(bright)];
        }
        public double Q
        {
            set
            {
                m_q = value;
            }
            get
            {
                return m_q;
            }
        }
        public byte[] Zscale
        {
            get
            {
                return m_z;
            }
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
