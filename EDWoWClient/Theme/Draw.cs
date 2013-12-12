/*
          _______ _____  _______ _______ _______ 
         |    ___|     \|    ___|   |   |   |   |
         |    ___|  --  |    ___|       |   |   |
         |_______|_____/|_______|__|_|__|_______| 
     Copyright (C) 2013 EmuDevs <http://www.emudevs.com/>
 
  This program is free software; you can redistribute it and/or modify it
  under the terms of the GNU General Public License as published by the
  Free Software Foundation; either version 2 of the License, or (at your
  option) any later version.
 
  This program is distributed in the hope that it will be useful, but WITHOUT
  ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
  FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for
  more details.
 
  You should have received a copy of the GNU General Public License along
  with this program. If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

public class Draw
{
    public static void Gradient(Graphics g, Color c1, Color c2, int x, int y, int width, int height)
    {
        Rectangle R = new Rectangle(x, y, width, height);
        using (LinearGradientBrush T = new LinearGradientBrush(R, c1, c2, LinearGradientMode.Vertical))
        {
            g.FillRectangle(T, R);
        }
    }
    public static void Blend(Graphics g, Color c1, Color c2, Color c3, float c, int d, int x, int y, int width, int height)
    {
        ColorBlend V = new ColorBlend(3);
        V.Colors = new Color[] { c1, c2, c3 };
        V.Positions = new float[] { 0F, c, 1F };
        Rectangle R = new Rectangle(x, y, width, height);
        using (LinearGradientBrush T = new LinearGradientBrush(R, c1, c1, (LinearGradientMode)d))
        {
            T.InterpolationColors = V;
            g.FillRectangle(T, R);
        }
    }
}
