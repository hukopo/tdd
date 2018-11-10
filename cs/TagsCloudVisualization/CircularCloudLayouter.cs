﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization
{
    class CircularCloudLayouter
    {
        public IReadOnlyCollection<Rectangle> Rectangles => rectangles.AsReadOnly();
        private readonly Point center;
        private readonly List<Rectangle> rectangles = new List<Rectangle>();
        private readonly IEnumerator<Point> composer;

        public CircularCloudLayouter(Point center)
        {
            this.center = center;
            composer = new RectanglesComposer(center).GetEnumerator();
        }

        public Rectangle PutNextRectangle(Size rectangleSize)
        {
            if (rectangleSize.Width < 0 || rectangleSize.Height < 0)
                throw new ArgumentException("size width and height must be a positive number");
            var rectangle = new Rectangle(
                new Point(center.X - rectangleSize.Width / 2, center.Y - rectangleSize.Height / 2), rectangleSize);
            while (rectangle.IntersectsWith(rectangles) && composer.MoveNext())
                rectangle.Location = composer.Current;
            rectangles.Add(rectangle);
            return rectangle;
        }
    }
    

}