//класс-буфер, в котором хранятся данные передаваемые между формами
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace OverleyEnhanced
{
    public static class Buffer
    {
        public static Bitmap source;
        public static List<ImageBox> imageList;
    }

    public class ImageBox
    {
        protected ImageWrapper m_imageJPEG;
        protected ImageWrapper m_imageSRGB;
        protected bool m_bflag = true;

        public ImageBox (ImageWrapper imageJPEG, ImageWrapper imageSRGB)
        {
            m_imageJPEG = imageJPEG;
            m_imageSRGB = imageSRGB;
        }

        public ImageWrapper Img
        {
            get
            {
                if (m_bflag) return m_imageJPEG;
                else return m_imageSRGB;
            }
        }

        public void SwitchImage()
        {
            if (m_bflag) m_bflag = false;
            else m_bflag = true;
        }
    }

    public abstract class EnhancedImageBox : ImageBox
    {
        public EnhancedImageBox(EnhancedImage imageJPEG, EnhancedImage imageSRGB) : base(imageJPEG, imageSRGB) {}

        protected double m_saturation = 0.5;
        protected byte m_criterion = 0;
        protected bool m_bupdateflag = false;
        protected bool m_parametersFlag = false;

        public void Update()
        {
            m_imageJPEG.Update();
            m_imageSRGB.Update();
            m_bupdateflag = false;
        }
        public double Saturation
        {
            get
            {
                return m_saturation;
            }
            set
            {
                m_bupdateflag = true;

                if (value > 1) m_saturation = 1;
                else if (value < 0) m_saturation = 0;
                else m_saturation = value;

                ((EnhancedImage)m_imageJPEG).Saturation = ((EnhancedImage)m_imageSRGB).Saturation = m_saturation;
            }
        }
        public byte Criterion
        {
            get
            {
                return m_criterion;
            }
            set
            {
                m_bupdateflag = true;

                m_criterion = value;
                ((EnhancedImage)m_imageJPEG).Criterion = ((EnhancedImage)m_imageSRGB).Criterion = m_criterion;
            }
        }
        public bool ParametersFlag
        {
            set
            {
                m_parametersFlag = value;
                ((EnhancedImage)m_imageJPEG).ParametersFlag = ((EnhancedImage)m_imageSRGB).ParametersFlag = m_parametersFlag;
            }
            get
            {
                return m_parametersFlag;
            }
        }
        public bool UpdateFlag
        {
            set
            {
                m_bupdateflag = value;
            }
            get
            {
                return m_bupdateflag;
            }
        }
    }

    public class ScretchImageBox : EnhancedImageBox
    {
        public ScretchImageBox(ScretchWrapper imageJPEG, ScretchWrapper imageSRGB) : base(imageJPEG, imageSRGB) {}

        protected double m_q = 0;

        public double Q
        {
            get
            {
                return m_q;
            }
            set
            {
                m_bupdateflag = true;
                m_q = value;
                ((ScretchWrapper)m_imageJPEG).Q = ((ScretchWrapper)m_imageSRGB).Q = m_q;
            }
        }
    }

    public class TeleImageBox : EnhancedImageBox
    {
        public TeleImageBox(TeleWrapper imageJPEG, TeleWrapper imageSRGB) : base(imageJPEG, imageSRGB) { }

        double m_qt = 1, m_qomega = 1;

        public double Qt
        {
            get
            {
                return m_qt;
            }
            set
            {
                m_bupdateflag = true;
                m_qt = value;
                ((TeleWrapper)m_imageJPEG).Qt = ((TeleWrapper)m_imageSRGB).Qt = m_qt;
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
                m_bupdateflag = true;
                m_qomega = value;
                ((TeleWrapper)m_imageJPEG).Qomega = ((TeleWrapper)m_imageSRGB).Qomega = m_qomega;
            }
        }
    }

    public class OverleyImageBox : EnhancedImageBox
    {
        public OverleyImageBox(OverleyWrapper imageJPEG, OverleyWrapper imageSRGB) : base(imageJPEG, imageSRGB) { }

        double m_k = 1;

        public double K
        {
            get
            {
                return m_k;
            }
            set
            {
                m_bupdateflag = true;

                if (value > 1) m_k = 1;
                else if (value < 0) m_k = 0;
                else m_k = value;

                ((OverleyWrapper)m_imageJPEG).K = ((OverleyWrapper)m_imageSRGB).K = m_k;
            }
        }
    }
}
