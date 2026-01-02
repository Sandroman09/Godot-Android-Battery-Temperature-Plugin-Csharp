using Godot;
using System;
using System.Xml;

public partial class Battery_degrees : Label
{

	private AndroidBatteryTemperature androidBatteryTemperature;

	public override void _Ready()
	{
		androidBatteryTemperature = GetNode<AndroidBatteryTemperature>("../AndroidBatteryTemperature");
		RefreshBatteryTemperature();
	}

	public void OnTimerTimeout() => RefreshBatteryTemperature();

	private void RefreshBatteryTemperature()
		=> Text = "Battery Temperature: " +  ((float)((int)(androidBatteryTemperature.GetBatteryTemperature() * 10)) / 10).ToString() + "C°";

	

}
