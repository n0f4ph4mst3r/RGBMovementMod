﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OverleyEnhanced
{
    public struct PerceptionCoffs
    {
        public readonly double k1, k2, k3;
        public PerceptionCoffs(double k1, double k2, double k3)
        {
            this.k1 = k1;
            this.k2 = k2;
            this.k3 = k3;
        }
    }
}
