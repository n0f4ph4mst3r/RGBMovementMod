using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OverleyEnhanced
{
    public class TeleWrapper : EnhancedImage
    {
        ScretchWrapper m_scretch;
        double m_qt = 1, m_qomega = 1; //задаваемые характеристики
        byte[] m_t; //промежуточная шкала
        public TeleWrapper(SourceWrapper src, ScretchWrapper scretch, MovementType movementType = MovementType.DEFAULT) : base(src, movementType) 
        {
            m_scretch = scretch;
            Update();
        }

        override public void Update()
        {
            double Tavg, omegat; //среднее t и омега с индексом t
            Tavg = m_qt * m_scretch.Avg;
            omegat = m_qomega * m_scretch.Dev;

            double Qinitial, Qexpected; //Q исходное и ожидаемое
            Qinitial = Tavg / ((SourceWrapper)m_source).Avg;
            Qexpected = (omegat / ((SourceWrapper)m_source).Dev - 1) / Qinitial;

            double temp;
            m_t = new byte[256];
            for (int i = 0; i < 256; i++)
            {
                temp = Qinitial * (i + Qexpected * (i - ((SourceWrapper)m_source).Avg));
                if (temp > 255)
                {
                    m_t[i] = 255;
                    continue;
                }
                if (temp < 0)
                {
                    m_t[i] = 0;
                    continue;
                }
                temp = Math.Round(temp);
                m_t[i] = (byte)temp;
            }
            base.Update();
        }
        override protected byte GetBright(byte bright)
        {
            return m_t[Convert.ToInt32(bright)];
        }
        public double Qt
        {
            get
            {
                return m_qt;
            }
            set
            {
                m_qt = value;
                Update();
            }
        }
        public double Qomega
        {
            get
            {
                return m_qomega;
            }
            set
            {
                m_qomega = value;
                Update();
            }
        }

        public byte[] Tscale
        {
            get
            {
                return m_t;
            }
        }
    }
}
