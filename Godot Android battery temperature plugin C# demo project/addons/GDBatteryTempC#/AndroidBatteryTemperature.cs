using Godot;
using System;






public partial class AndroidBatteryTemperature : Node
{
	private GodotObject _plugin;

	public override void _Ready()
	{
		if (OS.GetName() == "Android")
		{
			if (Engine.HasSingleton("GDBatteryTemp"))
				_plugin = Engine.GetSingleton("GDBatteryTemp");
			else
				GD.PrintErr("Plugin not found, Godot Android Temperature will not work");
		}
		else
			GD.PrintErr("Plugin not found, the platform is not android, Godot Android Temperature will not work");

	}

	
	//Call this function to get the battery temperature, it reuturns -100.0 if the value could not be found
	public float GetBatteryTemperature()
	{
		if (_plugin != null)
			return (float)_plugin.Call("getBatteryTemp");
		return -100.0f;
	}
}