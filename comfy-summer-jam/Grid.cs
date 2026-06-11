using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Numerics;

public partial class Grid : Node2D
{
	private TileMapLayer _groundTileMapLayer;
	private TileMapLayer _previewTileMapLayer;

	private bool _selectMode = false;

	private Vector2I _previewTile;
	public Vector2I PreviewTile 
	{
		set
		{
			if (_previewTile == value)
				return;
			_previewTileMapLayer.EraseCell(_previewTile);
			_previewTile = value;
			_previewTileMapLayer.SetCell(_previewTile);
		}
	}

	private int _gridSizeY = 5;
	private int _gridSizeX = 8;
	private Dictionary<string, string> Dic =  new Dictionary<string, string>();
	
	
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
			_previewTile = SnapPosition(GetGlobalMousePosition());
		}
		else
		{
			_previewTileMapLayer.EraseCell(_previewTile);
		}
	}
}
