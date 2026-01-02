#if TOOLS

using Godot;
using Godot.NativeInterop;
using System;
using System.ComponentModel;
using System.Diagnostics;
using GodotPlugins;


[Tool]
public partial class GDBatteryTemp : EditorPlugin
{
	private AndroidPlugin _exportPlugin;


    public override void _EnterTree()
	{
		_exportPlugin = new AndroidPlugin();
		AddExportPlugin(_exportPlugin);
		AddCustomType
		(
			"AndroidBatteryTemperature",
			"Node",
			GD.Load<CSharpScript>("res://addons/GDBatteryTempC#/AndroidBatteryTemperature.cs"),
			GD.Load<Texture2D>("res://addons/GDBatteryTempC#/BatteryIcon.png")
		);	
	}

    public override void _ExitTree()
    {
        RemoveExportPlugin(_exportPlugin);
		_exportPlugin = null;
    }


}

[Tool]
public partial class AndroidPlugin : EditorExportPlugin
{
    public override bool _SupportsPlatform(EditorExportPlatform platform)
    {
        if (platform is EditorExportPlatformAndroid)
			return true;
		return false;
    }


	

	public override string[] _GetAndroidLibraries(EditorExportPlatform platform, bool debug)
	{
		if (debug == true)
			return new string[] {"GDBatteryTempC#/app-release.aar"};
		else
			return new string[] {"GDBatteryTempC#/app-release.aar"};
	}

    public override string _GetName()
		=> "GDBatteryTemp";


}
#endif