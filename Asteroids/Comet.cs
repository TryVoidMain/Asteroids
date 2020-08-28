using System;
using System.Drawing;

namespace Asteroids
{
    class Comet:BaseObject
    {
        public Comet(Point pos, Point dir, Size size):base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.Silver, Pos.X, Pos.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.FillEllipse(Brushes.Silver, Pos.X, Pos.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.DrawEllipse(Pens.Red, Pos.X+15, Pos.Y+5, Size.Width*3, Size.Height/3);
        }
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width;
        }
    }
}
