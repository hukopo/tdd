﻿using System;
using System.Drawing;
namespace TagsCloudVisualization
{
    interface ICloudLayouter
    {
        Rectangle PutNextRectangle(Size rectangleSize);
    }
}
