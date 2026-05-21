using ModelingToolkit.Core;
using System.Collections.Generic;
using System.IO;
using Avalonia.Media.Imaging;

namespace ModelingToolkit
{
    public class MtHelper
    {
        public static readonly string KEY_VISIBLE = "MT_VISIBLE";
        public static readonly string KEY_WIREFRAME_VISIBLE = "MT_WIREFRAME_VISIBLE";

        public static bool MetadataIsTrue (Dictionary<string, string> metadata, string key, bool defaultValue = false)
        {
            if (!metadata.Keys.Contains(key))
            {
                metadata.Add(key, defaultValue.ToString());
                return defaultValue;
            }
            else return metadata[key] == "True";
        }

        public static Bitmap? GetImageSourceFromMaterial(MtMaterial material)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                if (material.DiffuseTextureBitmap == null)
                    return null;

                using var encoded = material.DiffuseTextureBitmap.Encode(SkiaSharp.SKEncodedImageFormat.Png, 100);
                encoded.SaveTo(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);

                return new Bitmap(memoryStream);
            }
        }

        public class Rect3D
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }
            public double SizeX { get; set; }
            public double SizeY { get; set; }
            public double SizeZ { get; set; }
        }

        public static Rect3D GetBoundingBox(MtModel model)
        {
            if (model.BoundingBox == null)
            {
                model.GenerateBoundingBox();
            }
            MtShape modelBB = model.BoundingBox;
            Rect3D bb = new Rect3D();
            bb.X = modelBB.Position.X;
            bb.Y = modelBB.Position.Y;
            bb.Z = modelBB.Position.Z;
            bb.SizeX = modelBB.Width;
            bb.SizeY = modelBB.Height;
            bb.SizeZ = modelBB.Depth;
            return bb;
        }
    }
}
