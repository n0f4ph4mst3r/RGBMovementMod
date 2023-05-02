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
        public static ImagePair source;
        public static List<ImagePair> imageList;
        public static List<ImagePair> imageList2;
    }

    public class ImagePair
    {
        protected ImageWrapper m_imageJPEG;
        protected ImageWrapper m_imageSRGB;
        protected bool m_bflag = true;

        public ImagePair (ImageWrapper imageJPEG, ImageWrapper imageSRGB)
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

        public bool UpdateFlag
        {
            set
            {
                m_imageJPEG.UpdateFlag = m_imageSRGB.UpdateFlag = value;
            }
            get
            {
                return Img.UpdateFlag;
            }
        }

        public void SwitchImage()
        {
            if (m_bflag) m_bflag = false;
            else m_bflag = true;
            Update();
        }

        public void Update()
        {
            if (Img.UpdateFlag)
            {
                Img.Update();
                Img.UpdateFlag = false;
            }
        }
    }

    public abstract class EnhancedImagePair : ImagePair
    {
        public EnhancedImagePair(EnhancedImage imageJPEG, EnhancedImage imageSRGB) : base(imageJPEG, imageSRGB) {}

        protected double m_saturation = 0.5;
        protected byte m_criterion = 0;
        protected bool m_parametersFlag = false;

        public double Saturation
        {
            get
            {
                return m_saturation;
            }
            set
            {
                UpdateFlag = true;

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
                UpdateFlag = true;
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
    }

    public class ScretchImagePair : EnhancedImagePair
    {
        public ScretchImagePair(ScretchWrapper imageJPEG, ScretchWrapper imageSRGB) : base(imageJPEG, imageSRGB) {}

        protected double m_q = 0;

        public double Q
        {
            get
            {
                return m_q;
            }
            set
            {
                UpdateFlag = true;
                m_q = value;
                ((ScretchWrapper)m_imageJPEG).Q = ((ScretchWrapper)m_imageSRGB).Q = m_q;
            }
        }
    }

    public class TeleImagePair : EnhancedImagePair
    {
        public TeleImagePair(TeleWrapper imageJPEG, TeleWrapper imageSRGB) : base(imageJPEG, imageSRGB) { }

        double m_qt = 1, m_qomega = 1;

        public double Qt
        {
            get
            {
                return m_qt;
            }
            set
            {
                UpdateFlag = true;
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
                UpdateFlag = true;
                m_qomega = value;
                ((TeleWrapper)m_imageJPEG).Qomega = ((TeleWrapper)m_imageSRGB).Qomega = m_qomega;
            }
        }
    }

    public class OverleyImagePair : EnhancedImagePair
    {
        public OverleyImagePair(OverleyWrapper imageJPEG, OverleyWrapper imageSRGB) : base(imageJPEG, imageSRGB) { }

        double m_k = 1;

        public double K
        {
            get
            {
                return m_k;
            }
            set
            {
                UpdateFlag = true;

                if (value > 1) m_k = 1;
                else if (value < 0) m_k = 0;
                else m_k = value;

                ((OverleyWrapper)m_imageJPEG).K = ((OverleyWrapper)m_imageSRGB).K = m_k;
            }
        }
    }
}
