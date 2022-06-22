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
        public static ImageContainer JPEGConatiner = new ImageContainer(new PerceptionCoffs(0.299, 0.587, 0.114));
        public static ImageContainer sRGBConatiner = new ImageContainer(new PerceptionCoffs(0.2126, 0.7152, 0.0722));
    }
}
