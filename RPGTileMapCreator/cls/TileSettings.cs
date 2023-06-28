using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGTileMapCreator.cls
{
    public class TileSettings
    {
        public string TileFilePath { get; set; }
        public List<Tile> Tiles { get; set; }
    }

    public class Tile
    {
        public string FileName { get; set; }
        public string Character { get; set; }
    }

    public class Root
    {
        public TileSettings TileSettings { get; set; }
    }

    public class ProjectFile
    {
        public string ProjectFolder { get; set; }
        public string MapFile { get; set; }
        public string TileFolder { get; set; }
        public string TileSettingsFile { get; set; }
    }

}
