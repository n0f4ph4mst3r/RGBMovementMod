using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OverleyEnhanced
{
    public class OverleyWrapper : EnhancedImage
    {
        ScretchWrapper m_scretch;
        TeleWrapper m_tele;

        double m_k = 1;

        public OverleyWrapper(SourceWrapper src, ScretchWrapper scretch, TeleWrapper tele) : base (src)
        {
            m_scretch = scretch;
            m_tele = tele;
            Update();
        }
        override protected byte GetBright(byte bright)
        {
            return (byte)(m_k * m_scretch.Zscale[Convert.ToInt32(bright)] + (1 - m_k) * m_tele.Tscale[Convert.ToInt32(bright)]);
        }
        public double K
        {
            get
            {
                return m_k;
            }
            set
            {
                if (value > 1) m_k = 1;
                else if (value < 0) m_k = 0;
                else m_k = value;
            }
        }
    }
}

