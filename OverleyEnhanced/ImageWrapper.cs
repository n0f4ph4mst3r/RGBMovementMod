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
        protected PerceptionCoffs coffs; //коэффциенты восприятия
        protected Bitmap bit; //изображение
        protected int n; //общее число пикселей
        protected byte[] y; //шкала яркости
        protected byte[] bytes; //значения пикселей
        protected List<double> frequencyList; //шкала частот
        public virtual void Update()
        {
            n = bit.Width * bit.Height;
            bytes = new byte[n * 3];
            y = new byte[n];
        }
        protected void SetFrequencys()
        {
            frequencyList = new List<double>(256);
            for (int i = 0; i < frequencyList.Capacity; ++i)
            {
                frequencyList.Add(0);
            }
            //определяем шкалу частот
            for (int i = 0; i < y.Length; ++i)
            {
                frequencyList[GetBright(y[i])]++; //инкриментируем элемент с индексом равному полученной яркости в шкале частот
            }
            for (int i = 0; i < 256; i++)
            {
                frequencyList[i] /= n; //определяем частоту путем деления на количество пикселей
            }
        }
        protected virtual byte GetBright(in byte bright) 
        {
            return bright;
        } 
        public virtual Bitmap Bit
        {
            get
            {
                return bit;
            }
        }
        public int N
        {
            get
            {
                return n;
            }
        }
        public virtual byte[] Bytes
        {
            get
            {
                return bytes;
            }
        }
        public byte[] Yscale
        {
            get
            {
                return y;
            }
        }
        public List<double> FrequencyScale
        {
            get
            {
                return frequencyList;
            }
        }
        public PerceptionCoffs Coffs
        {
            get
            {
                return coffs;
            }
        }
    }
}
