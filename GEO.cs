//Written for Children of Orc. https://store.steampowered.com/app/544840/
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace CoO_GEO
{
    public class GEO
    {
        private readonly List<Vector3> points = new();
        private readonly List<float> color = new();
        private readonly List<Vector3> faces = new();

        public static GEO Read(string GEOFile)
        {
            BinaryReader br = new(File.OpenRead(GEOFile));

            if (new string(br.ReadChars(4)) != "geo ")
                throw new System.Exception("Wrong file. Input a geo file from Children of Orc.");

            br.ReadInt32();//Unknown
            int faceCount = br.ReadInt32();//Unknown

            GEO geo = new();
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                geo.points.Add(new(br.ReadInt32(), br.ReadInt32(), br.ReadInt32()));
                geo.color.Add(br.ReadSingle());
            }

            for (int i = 0; i < geo.points.Count / 3; i++)
            {
                geo.faces.Add(new Vector3(i * 3, i * 3 + 1, i * 3 + 2));
            }

            return geo;
        }
    }
}
