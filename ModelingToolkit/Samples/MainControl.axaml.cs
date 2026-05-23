using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using ModelingToolkit.Core;
using ModelingToolkit.Formats;
using ModelingToolkit.Formats.MtAssimp;

namespace ModelingToolkit.Samples;

public partial class MainControl : UserControl
{
	public string LoadedFile { get; set; }
	public MtScene Scene { get; set; }

	public MainControl()
	{
		InitializeComponent();
	}

	private void Button_reload(object sender, RoutedEventArgs e)
	{
		// Loading via file dialog is not available in this minimal cross-platform scaffold.
		// Use external code to set `LoadedFile` and call `loadFile()` if needed.
	}

	public void loadFile()
	{
		if (!string.IsNullOrEmpty(LoadedFile))
		{
			Scene = AssimpImporter.ImportScene(LoadedFile);
		}
	}

	private void Button_Mesh(object sender, RoutedEventArgs e) { }
	private void Button_Wireframe(object sender, RoutedEventArgs e) { }
	private void Button_skeleton(object sender, RoutedEventArgs e) { }
	private void Button_joints(object sender, RoutedEventArgs e) { }
	private void Button_boundingBox(object sender, RoutedEventArgs e) { }

	private void MenuItem_ExportGltf(object sender, RoutedEventArgs e)
	{
		if (string.IsNullOrEmpty(LoadedFile) || Scene == null) return;
		string dirPath = Path.GetDirectoryName(LoadedFile) ?? ".";
		string outFile = Path.Combine(dirPath, Path.GetFileNameWithoutExtension(LoadedFile) + ".gltf");
		MtPorter.ExportScene(Scene, outFile, MtPorter.FileType.GLTF);
	}

	private void MenuItem_ExportGlb(object sender, RoutedEventArgs e)
	{
		if (string.IsNullOrEmpty(LoadedFile) || Scene == null) return;
		string dirPath = Path.GetDirectoryName(LoadedFile) ?? ".";
		string outFile = Path.Combine(dirPath, Path.GetFileNameWithoutExtension(LoadedFile) + ".glb");
		MtPorter.ExportScene(Scene, outFile, MtPorter.FileType.GLB);
	}

	private void MenuItem_ExportFbx(object sender, RoutedEventArgs e)
	{
		if (string.IsNullOrEmpty(LoadedFile) || Scene == null) return;
		string dirPath = Path.GetDirectoryName(LoadedFile) ?? ".";
		string outFile = Path.Combine(dirPath, Path.GetFileNameWithoutExtension(LoadedFile) + ".fbx");
		MtPorter.ExportScene(Scene, outFile, MtPorter.FileType.FBX);
	}
}
