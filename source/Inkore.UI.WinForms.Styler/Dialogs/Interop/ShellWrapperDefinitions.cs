using System;
using System.Runtime.InteropServices;

namespace Inkore.UI.WinForms.Styler.Dialogs.Interop
{
	// Dummy base interface for CommonFileDialog coclasses
	internal interface NativeCommonFileDialog
	{ }

	// ---------------------------------------------------------
	// Coclass interfaces - designed to "look like" the object 
	// in the API, so that the 'new' operator can be used in a 
	// straightforward way. Behind the scenes, the C# compiler
	// morphs all 'new CoClass()' calls to 'new CoClassWrapper()'
	[ComImport,
	Guid(IIDGuid.IFileOpenDialog),
	CoClass(typeof(FileOpenDialogRCW))]
	internal interface NativeFileOpenDialog : IFileOpenDialog
	{
	}

	[ComImport,
	Guid(IIDGuid.IFileSaveDialog),
	CoClass(typeof(FileSaveDialogRCW))]
	internal interface NativeFileSaveDialog : IFileSaveDialog
	{
	}

	[ComImport,
	Guid(IIDGuid.IKnownFolderManager),
	CoClass(typeof(KnownFolderManagerRCW))]
	internal interface KnownFolderManager : IKnownFolderManager
	{
	}

	// ---------------------------------------------------
	// .NET classes representing runtime callable wrappers
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1812:Avoid uninstantiated internal classes", Justification = "<pending>")]
	[ComImport,
	ClassInterface(ClassInterfaceType.None),
	TypeLibType(TypeLibTypeFlags.FCanCreate),
	Guid(CLSIDGuid.FileOpenDialog)]
	internal class FileOpenDialogRCW
	{
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1812:Avoid uninstantiated internal classes", Justification = "<pending>")]
	[ComImport,
	ClassInterface(ClassInterfaceType.None),
	TypeLibType(TypeLibTypeFlags.FCanCreate),
	Guid(CLSIDGuid.FileSaveDialog)]
	internal class FileSaveDialogRCW
	{
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1812:Avoid uninstantiated internal classes", Justification = "<pending>")]
	[ComImport,
	ClassInterface(ClassInterfaceType.None),
	TypeLibType(TypeLibTypeFlags.FCanCreate),
	Guid(CLSIDGuid.KnownFolderManager)]
	internal class KnownFolderManagerRCW
	{
	}
}
