using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SerpinskisCarpet
{
    internal class ColoredRectangle
    {
        Rectangle tangle;
        Color colourBritish;

        ColoredRectangle()
        {
            tangle = new Rectangle();
            colourBritish = Color.Black;
        }

        ColoredRectangle(Rectangle tangle)
        {
            this.tangle = tangle;
            colourBritish = Color.Black;
        }
        ColoredRectangle(Color colourBritish)
        {
            tangle = new Rectangle();
            this.colourBritish = colourBritish;
        }
        ColoredRectangle(Rectangle tangle, Color colourBritish)
        {
            this.tangle = tangle;
            this.colourBritish = colourBritish;
        }
    }
}
