using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGTileMapCreator.cls
{
    public class TileSettings
    {
        public string tileFilePath { get; set; }
        public List<Tileset> tilesets { get; set; }
    }

    public class Tileset
    {
        public string fileName { get; set; }
        public string character { get; set; }
    }

    public class Root
    {
        public TileSettings tileSettings { get; set; }
    }
}
