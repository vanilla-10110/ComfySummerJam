using Godot;
using System;

public partial class MainMenu : Control
{


	[Export]
	private Button _startButton;
	[Export]
	private Button _settingsButton;
	[Export]
	private Button _quitButton;
	[Export]
	private CanvasItem _mainMenuCanvas;
	



	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_startButton.Pressed += StartButtonPressed;
		_settingsButton.Pressed += SettingsButtonPressed;
		_quitButton.Pressed += QuitButtonPressed;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void StartButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://Main_Scene.tscn");

	}
	private void SettingsButtonPressed()
	{
		_mainMenuCanvas.Visible= false;
	}
	private void QuitButtonPressed()
	{
		GetTree().Quit();
	}


}
