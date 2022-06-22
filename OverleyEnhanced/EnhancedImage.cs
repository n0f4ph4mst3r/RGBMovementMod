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
        ImageWrapper m_source; //исходное изображение
        double m_saturation; //насыщенность
        byte m_criterion; //критерий насыщения
        public EnhancedImage (in ImageWrapper src) 
        {
            Update(src);
        }
        public void Update(in ImageWrapper src)
        {
            m_source = src;
            Update();
        }
        public override void Update()
        {
            bit = new Bitmap(m_source.Bit.Width, m_source.Bit.Height);
            base.Update();
            Array.Copy(m_source.Bytes, bytes, m_source.Bytes.Length);
            Array.Copy(m_source.Yscale, y, m_source.Yscale.Length);

            for (int i = 0; i < bytes.Length; i += 3)
            {
                int j = i / 3;
                double dy = m_source.Yscale[j] - y[j];
                double q = dy / y[j];

                void MovePixel(Func<byte, byte> movement)
                {
                    for (int k = i; k < i + 3; ++k)
                    {
                        bytes[k] += movement(bytes[k]);
                    }
                };
                byte PixelMovement1(byte value) => (byte)(q * value);
                byte PixelMovement2(byte value) => (byte)(q * ((1 - m_saturation) * value + m_saturation * y[j] * (255 - value) / (255 - y[j])));

                if (dy < 0)
                {
                    MovePixel(PixelMovement1);
                }
                else
                {
                    byte[] point = { bytes[i], bytes[i + 1], bytes[i + 2] };
                    byte mmin = point.Min();
                    Func<byte, byte> movement = y[j] < m_criterion ? movement = PixelMovement1 : movement = PixelMovement2;
                    double dm = movement(mmin);
                    double m1 = dm + mmin;
                    if (m1 <= 255)
                    {
                        MovePixel(movement);
                    }
                    else
                    {
                        m1 = 255;
                        dm = m1 - mmin;
                        q = y[j] < m_criterion ? dm / mmin : dm / ((1 - m_saturation) * mmin + m_saturation * y[j] * (255 - mmin) / (255 - y[j]));

                        double dy1 = q * y[j];
                        for (int k = 0; k < 3; ++k)
                        {
                            bytes[i + k] += movement(point[k]);
                        }

                        double dy2 = dy - dy1;
                        double f = dy2 / (255 - y[j]);
                        byte PixelMovement3(byte value) => (byte)(f * (255 - value));
                        MovePixel(PixelMovement3);
                    }
                }
            }
            SetFrequencys();
            //записываем битмап
            BitmapData databit = bit.LockBits(new Rectangle(0, 0, bit.Width, bit.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            IntPtr pointer = databit.Scan0;
            Marshal.Copy(bytes, 0, pointer, bytes.Length);
            bit.UnlockBits(databit);
        }
        public double Saturation
        {
            set
            {
                if (value > 1) m_saturation = 1;
                else if(value < 0) m_saturation = 0;
                else m_saturation = value;
                Update();
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
                Update();
            }
            get
            {
                return m_criterion;
            }
        }
    }
}



