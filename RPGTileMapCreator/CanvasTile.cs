using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RPGTileMapCreator
{
    public class CanvasTile
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Point TopLeftPoint { get; set; }
        public Point BottomRightPoint { get; set; }
        public string Character { get; set; }
        public Image TileImage { get; set; }
    }
}
