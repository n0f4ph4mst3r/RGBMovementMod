using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OverleyEnhanced
{
    abstract public class ImageWrapper
    {
        protected PerceptionCoffs m_coffs; //коэффциенты восприятия
        protected Bitmap m_bit; //изображение
        protected int m_n; //общее число пикселей
        protected byte[] m_y; //шкала яркости
        protected byte[] m_bytes; //значения пикселей
        protected List<double> m_frequencyList = new List<double>(256); //шкала частот
        protected bool m_updateFlag = false;
        public virtual void Update()
        {
            m_n = m_bit.Width * m_bit.Height;
            m_bytes = new byte[m_n * 3];
            m_y = new byte[m_n];
        }
        protected void SetFrequencys()
        {
            m_frequencyList.Clear();
            for (int i = 0; i < m_frequencyList.Capacity; ++i)
            {
                m_frequencyList.Add(0);
            }
            //определяем шкалу частот
            for (int i = 0; i < m_y.Length; ++i)
            {
                m_frequencyList[m_y[i]]++; //инкриментируем элемент с индексом равному полученной яркости в шкале частот
            }
            for (int i = 0; i < 256; i++)
            {
                m_frequencyList[i] /= m_n; //определяем частоту путем деления на количество пикселей
            }
        }
        public virtual Bitmap Bit
        {
            get
            {
                return m_bit;
            }
        }
        public int N
        {
            get
            {
                return m_n;
            }
        }
        public virtual byte[] Bytes
        {
            get
            {
                return m_bytes;
            }
        }
        public byte[] Yscale
        {
            get
            {
                return m_y;
            }
        }
        public List<double> FrequencyScale
        {
            get
            {
                return m_frequencyList;
            }
        }
        public PerceptionCoffs Coffs
        {
            get
            {
                return m_coffs;
            }
        }
        public bool UpdateFlag
        {
            set
            {
                m_updateFlag = value;
            }
            get
            {
                return m_updateFlag;
            }
        }
    }
}
