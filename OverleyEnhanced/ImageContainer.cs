using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace OverleyEnhanced
{
    public struct ImageContainer
    {
        PerceptionCoffs m_coffs;
        List<ImageWrapper> m_imageList;
        public ImageContainer(PerceptionCoffs coffs)
        {
            m_coffs = coffs;
            m_imageList = new List<ImageWrapper>(4);
        }
        public void Update (in Bitmap src)
        {
            m_imageList[0] = new SourceWrapper(src, m_coffs);
            m_imageList[1] = new ScretchWrapper(m_imageList[0] as SourceWrapper);
        }
        public void Update(BitmapType bitmap)
        {
            switch (bitmap)
            {
                case BitmapType.OVERLEY:
                    m_imageList[3].Update();
                    break;
                default:
                    int index = (int)bitmap;
                    m_imageList[index].Update();
                    for (int i = index + 1; i < m_imageList.Count(); ++i)
                    {
                        EnhancedImage item = m_imageList[i] as EnhancedImage;
                        item.Update(m_imageList[i - 1]);
                    }
                    break;
            }
        }
        public PerceptionCoffs Coffs
        {
            get
            {
                return m_coffs;
            }
        }
        public List<ImageWrapper> ImageList
        {
            get
            {
                return m_imageList;
            }
        }
    }
    public enum BitmapType
    {
        SOURCE,
        SCRETCH,
        TELE,
        OVERLEY
    }
}
