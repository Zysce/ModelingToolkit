using ModelingToolkit.Core;
using System.Collections.Generic;
using System.IO;
using Avalonia.Media.Imaging;

namespace ModelingToolkit.Helpers;

public partial class MtHelper
{
	public static readonly string KEY_VISIBLE = "MT_VISIBLE";
	public static readonly string KEY_WIREFRAME_VISIBLE = "MT_WIREFRAME_VISIBLE";

	public static bool MetadataIsTrue(Dictionary<string, string> metadata, string key, bool defaultValue = false)
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
		using MemoryStream memoryStream = new MemoryStream();
		if (material.DiffuseTextureBitmap == null)
		{
			return null;
		}

		using var encoded = material.DiffuseTextureBitmap.Encode(SkiaSharp.SKEncodedImageFormat.Png, 100);
		encoded.SaveTo(memoryStream);
		memoryStream.Seek(0, SeekOrigin.Begin);

		return new Bitmap(memoryStream);
	}

	public static Rect3D GetBoundingBox(MtModel model)
	{
		if (model.BoundingBox == null)
		{
			model.GenerateBoundingBox();
		}
		MtShape modelBB = model.BoundingBox;
		return new Rect3D
		{
			X = modelBB.Position.X,
			Y = modelBB.Position.Y,
			Z = modelBB.Position.Z,
			SizeX = modelBB.Width,
			SizeY = modelBB.Height,
			SizeZ = modelBB.Depth
		};
	}
}
