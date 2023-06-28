using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGTileMapCreator.cls
{
    public class Project
    {
        public string Name;
        public string ProjectFolder;
        public string MapFilePath;
        public string TileFolderPath;
        public string TileSetFile;
        public int StartingWidth;
        public int StartingHeight;
        public int TileWidth;
        public int TileHeight;
        public string EmptyTileCharacter;
        public List<Tile> Tiles { get; set; }
    }
}
