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
        public enum MovementType
        {
            DEFAULT,
            ENHANCED
        }

        protected ImageWrapper m_source; //исходное изображение
        protected double m_saturation = 0.5; //насыщенность
        protected byte m_criterion = 0; //критерий насыщения
        protected bool m_parametersFlag = false;

        protected delegate void PixelMovement(ref byte value, byte y0);
        protected delegate void MoveHanlder();
        MoveHanlder m_moveHandler;

        public EnhancedImage (ImageWrapper src, MovementType movementType = MovementType.DEFAULT)
        {
            m_source = src;
            switch (movementType)
            {
                case MovementType.ENHANCED:
                    m_moveHandler = () =>
                    {
                        for (int i = 0; i < m_bytes.Length; i += 3)
                        {
                            int j = i / 3;
                            double dy = m_y[j] - m_source.Yscale[j];

                            byte[] bytes0 = new byte[] { m_source.Bytes[i], m_source.Bytes[i + 1], m_source.Bytes[i + 2] };
                            byte[] bytes = new byte[] { m_bytes[i], m_bytes[i + 1], m_bytes[i + 2] };

                            if (dy != 0 && m_y[j] != 0)
                            {
                                if (bytes0[0] == bytes0[1] && bytes0[0] == bytes0[2])
                                {
                                    MovePixel(i, ref bytes0, (ref byte value, byte y0) => value = (byte)(y0 + dy));
                                }
                                else
                                {
                                    double z1 = bytes0.Min();
                                    double z2 = bytes0.Max();

                                    double q = dy / m_source.Yscale[j];
                                    double q1 = 255 / (z1 + z2) - 1;
                                    double f = dy / (255 - m_source.Yscale[j]);

                                    PixelMovement movement1 = (ref byte value, byte y0) => value = (byte)((q + 1) * y0);
                                    PixelMovement movement2 = (ref byte value, byte y0) => value = (byte)(f * (255 - y0) + y0);

                                    if (q == 0)
                                    {
                                        if (dy < 0)
                                        {
                                            MovePixel(i, ref bytes0, movement1);
                                        }
                                        else
                                        {
                                            MovePixel(i, ref bytes0, movement2);
                                        }
                                    }
                                    else if (q > 0)
                                    {
                                        if (q <= q1)
                                        {
                                            MovePixel(i, ref bytes0, movement1);
                                        }
                                        else
                                        {
                                            MovePixel(i, ref bytes0, (ref byte value, byte y0) => value = (byte)((q1 + 1) * y0));
                                            double dy1 = q1 * m_source.Yscale[j];
                                            double y1 = m_source.Yscale[j] + dy1;
                                            double dy2 = dy - dy1;
                                            f = dy2 / (255 - y1);

                                            bytes = new byte[] { m_bytes[i], m_bytes[i + 1], m_bytes[i + 2] };
                                            MovePixel(i, ref bytes, movement2);
                                        }
                                    }
                                    else
                                    {
                                        double f1 = (255 - (z1 + z2)) / (510 - (z1 + z2));
                                        if (f >= f1)
                                        {
                                            MovePixel(i, ref bytes0, movement1);
                                        }
                                        else
                                        {
                                            MovePixel(i, ref bytes0, (ref byte value, byte y0) => value = (byte)(f1 * (255 - y0) + y0));
                                            double dy1 = f1 * (255 - m_source.Yscale[j]);
                                            double y1 = m_source.Yscale[j] + dy1;
                                            double dy2 = dy - dy1;
                                            q = dy2 / y1;

                                            bytes = new byte[] { m_bytes[i], m_bytes[i + 1], m_bytes[i + 2] };
                                            MovePixel(i, ref bytes, movement1);
                                        }
                                    }
                                }
                            }
                            else MovePixel(i, ref bytes0, (ref byte value, byte y0) => { value = y0; });
                        }
                    };
                            break;
                default:
                    m_moveHandler = () =>
                    {
                        for (int i = 0; i < m_bytes.Length; i += 3)
                        {
                            int j = i / 3;
                            double dy = m_y[j] - m_source.Yscale[j];
                            byte[] bytes0 = new byte[] { m_source.Bytes[i], m_source.Bytes[i + 1], m_source.Bytes[i + 2] };

                            if (dy != 0 && m_y[j] != 0)
                            {
                                double q = dy / m_source.Yscale[j];

                                PixelMovement movement1 = (ref byte value, byte y0) => value = (byte)(y0 + (q * y0));
                                PixelMovement movement2 = (ref byte value, byte y0) => value = (byte)(y0 + q * ((1 - m_saturation) * y0 + m_saturation * m_source.Yscale[j] * (255 - y0) / (255 - m_source.Yscale[j])));

                                if (dy < 0)
                                {
                                    MovePixel(i, ref bytes0, movement1);
                                }
                                else
                                {
                                    byte mmax = bytes0.Max();
                                    byte dm = m_parametersFlag && m_y[j] < m_criterion ? (byte)(q * ((1 - m_saturation) * mmax + m_saturation * m_source.Yscale[j] * (255 - mmax) / (255 - m_source.Yscale[j]))) : (byte)(q * mmax);
                                    double m1 = mmax + dm;
                                    PixelMovement movement = m_parametersFlag && m_y[j] < m_criterion ? movement2 : movement1;

                                    if (m1 <= 255)
                                    {
                                        MovePixel(i, ref bytes0, movement);
                                    }
                                    else
                                    {
                                        m1 = 255;
                                        dm = (byte)(m1 - mmax);
                                        q = dm / mmax;

                                        double dy1 = m_parametersFlag && m_y[j] < m_criterion ? 
                                          m_coffs.k1 * q * ((1 - m_saturation) * bytes0[0] + m_saturation * m_source.Yscale[j] * (255 - bytes0[0]) / (255 - m_source.Yscale[j]))
                                        + m_coffs.k2 * q * ((1 - m_saturation) * bytes0[1] + m_saturation * m_source.Yscale[j] * (255 - bytes0[1]) / (255 - m_source.Yscale[j]))
                                        + m_coffs.k3 * q * ((1 - m_saturation) * bytes0[2] + m_saturation * m_source.Yscale[j] * (255 - bytes0[2]) / (255 - m_source.Yscale[j]))
                                        : m_coffs.k1 * q * bytes0[0] + m_coffs.k2 * q * bytes0[1] + m_coffs.k3 * q * bytes0[2];

                                        MovePixel(i, ref bytes0, movement);

                                        double y1 = m_source.Yscale[j] + dy1;
                                        double dy2 = dy - dy1;
                                        double f = dy2 / (255 - y1);
                                        PixelMovement movement3 = (ref byte value, byte y0) => value = (byte)(y0 + (f * (255 - y0)));

                                        byte[] bytes = new byte[] { m_bytes[i], m_bytes[i + 1], m_bytes[i + 2] };
                                        MovePixel(i, ref bytes, movement3);
                                    }
                                }
                            }
                            else MovePixel(i, ref bytes0, (ref byte value, byte y0) => { value = y0; });
                        }
                    };
                    break;
            }
        }
        
        public override void Update()
        {
            //считываем битмап и шкалу яркости
            m_bit = new Bitmap(m_source.Bit.Width, m_source.Bit.Height);
            base.Update();
            Array.Copy(m_source.Bytes, m_bytes, m_source.Bytes.Length);
            Array.Copy(m_source.Yscale, m_y, m_source.Yscale.Length);
            for (int i = 0; i < m_y.Length; ++i)
            {
                m_y[i] = GetBright(m_y[i]);
            }

            m_moveHandler();
            SetFrequencys();

            //записываем битмап
            BitmapData databit = m_bit.LockBits(new Rectangle(0, 0, m_bit.Width, m_bit.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            IntPtr pointer = databit.Scan0;
            Marshal.Copy(m_bytes, 0, pointer, m_bytes.Length);
            m_bit.UnlockBits(databit);
        }
        protected void MovePixel(int pos, ref byte[] y0, PixelMovement movement)
        {
            for (int i = 0; i < 3; ++i)
            {
                movement(ref m_bytes[pos + i], y0[i]);
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



