using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGTileMapCreator
{
    public class PaletteObject
    {
        public PictureBox tile;
        public TextBox letter;

        public PaletteObject()
        {

        }
        public PaletteObject(PictureBox p, TextBox t)
        {
            tile = p;
            letter = t;
        }
    }
}
