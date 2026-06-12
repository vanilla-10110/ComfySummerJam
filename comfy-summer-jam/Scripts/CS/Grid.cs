using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Numerics;

public partial class Grid : Node2D
{
	private TileMapLayer _groundTileMapLayer;
	private TileMapLayer _previewTileMapLayer;

	private Vector2I _selectedTile;

	private bool _selectMode = false;

	private PackedScene _building = GD.Load<PackedScene>("res://Ranged_Building.tscn");
	
	
	private Vector2I _previewTile;
	public Vector2I PreviewTile 
	{
		set
		{
			if (_previewTile == value)
				return;
			_previewTileMapLayer.EraseCell(_previewTile);
			_previewTile = value;
			_previewTileMapLayer.SetCell(value, 1, _selectedTile);
		}
	}

	private int _gridSizeY = 5;
	private int _gridSizeX = 8;
	private Dictionary<string, string> Dic =  new Dictionary<string, string>();

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseEvent)
		{
			if (mouseEvent.ButtonIndex == MouseButton.Left && mouseEvent.Pressed)
			{
				GD.Print($"Left Mouse Pressed at Position {mouseEvent.Position}");
				LeftMouseClick();
			}
				
		}
		base._Input(@event);
	}


	public override void _Ready()
	{
		_groundTileMapLayer = GetNode<TileMapLayer>("ground");
		_previewTileMapLayer = GetNode<TileMapLayer>("preview");

		for (int x = 0; x < _gridSizeX; x++)
		{
			for (int y = 0; y < _gridSizeY; y++)
			{
				_groundTileMapLayer.SetCell(new Vector2I(x, y), 0, new Vector2I(0,0));
			}
		}

		_selectMode = true;
	}

	private Vector2I SnapPosition(Vector2 globalPosition)
	{
		Vector2 localPosition = _groundTileMapLayer.ToLocal(globalPosition);
		Vector2I tilePosition = _groundTileMapLayer.LocalToMap(localPosition);
		
		return tilePosition;
	}

	public override void _Process(double delta)
	{
		Vector2I[] workingSpace = _groundTileMapLayer.GetUsedCells().ToArray();
		if (workingSpace.Contains(SnapPosition(GetGlobalMousePosition())))    
		{
			PreviewTile = SnapPosition(GetGlobalMousePosition());
		}
		else
		{
			_previewTileMapLayer.EraseCell(_previewTile);
		}
	}

	private void LeftMouseClick()
	{
		Vector2I[] workingSpace = _previewTileMapLayer.GetUsedCells().ToArray();
		Vector2I currentTile = SnapPosition(GetGlobalMousePosition());
		if (workingSpace.Contains(currentTile))
		{
			var instance = _building.Instantiate();
			AddChild(instance);
		}
	}
	
	
}
