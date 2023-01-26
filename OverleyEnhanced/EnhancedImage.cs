using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OverleyEnhanced
{
    abstract public class EnhancedImage : ImageWrapper
    {
        protected ImageWrapper m_source; //исходное изображение
        protected double m_saturation = 0.5; //насыщенность
        protected byte m_criterion = 0; //критерий насыщения
        protected bool m_parametersFlag = false;

        protected delegate byte PixelMovement(byte value);

        public EnhancedImage (ImageWrapper src)
        {
            m_source = src;
        }
        
        public override void Update()
        {
            m_bit = new Bitmap(m_source.Bit.Width, m_source.Bit.Height);
            base.Update();
            Array.Copy(m_source.Bytes, m_bytes, m_source.Bytes.Length);
            Array.Copy(m_source.Yscale, m_y, m_source.Yscale.Length);
            for (int i = 0; i < m_y.Length; ++i)
            {
                m_y[i] = GetBright(m_y[i]);
            }

            for (int i = 0; i < m_bytes.Length; i += 3)
            {
                int j = i / 3;
                double dy = m_y[j] - m_source.Yscale[j];
                if (dy != 0 && m_y[j] != 0)
                {
                    double q = dy / m_y[j];
                    
                    PixelMovement movement1 = value => (byte)(q * value);
                    PixelMovement movement2 = value => (byte)(q * ((1 - m_saturation) * value + m_saturation * m_y[j] * (255 - value) / (255 - m_y[j])));

                    if (m_parametersFlag)
                    {
                        if (dy < 0)
                        {
                            MovePixel(movement1, i);
                        }
                        else
                        {
                            byte[] point = { m_bytes[i], m_bytes[i + 1], m_bytes[i + 2] };
                            byte mmin = point.Min();
                            PixelMovement movement = m_y[j] < m_criterion ? movement = movement2 : movement = movement1;
                            double dm = movement(mmin);
                            double m1 = dm + mmin;
                            if (m1 <= 255)
                            {
                                MovePixel(movement, i);
                            }
                            else
                            {
                                m1 = 255;
                                dm = m1 - mmin;
                                q = m_y[j] < m_criterion ? dm / mmin : dm / ((1 - m_saturation) * mmin + m_saturation * m_y[j] * (255 - mmin) / (255 - m_y[j]));

                                double dy1 = q * m_y[j];
                                for (int k = 0; k < 3; ++k)
                                {
                                    m_bytes[i + k] += movement(point[k]);
                                }

                                double dy2 = dy - dy1;
                                double f = dy2 / (255 - m_y[j]);
                                PixelMovement movement3 = value => (byte)(f * (255 - value));
                                MovePixel(movement3, i);
                            }
                        }
                    }
                    else
                    {
                        MovePixel(movement1, i);
                    }
                }
            }
            SetFrequencys();
            //записываем битмап
            BitmapData databit = m_bit.LockBits(new Rectangle(0, 0, m_bit.Width, m_bit.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            IntPtr pointer = databit.Scan0;
            Marshal.Copy(m_bytes, 0, pointer, m_bytes.Length);
            m_bit.UnlockBits(databit);
        }
        protected void MovePixel(PixelMovement movement, int i)
        {
            for (int k = i; k < i + 3; ++k)
            {
                m_bytes[k] += movement(m_bytes[k]);
            }
        }
        protected virtual byte GetBright(byte bright)
        {
            return bright;
        }
        public double Saturation
        {
            set
            {
                if (value > 1) m_saturation = 1;
                else if(value < 0) m_saturation = 0;
                else m_saturation = value;
            }
            get
            {
                return m_saturation;
            }
        }
        public byte Criterion
        {
            set
            {
                m_criterion = value;
            }
            get
            {
                return m_criterion;
            }
        }
        public bool ParametersFlag
        {
            set
            {
                m_parametersFlag = value;
            }
            get
            {
                return m_parametersFlag;
            }
        }
    }
}



