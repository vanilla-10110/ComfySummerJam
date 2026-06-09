extends Node2D

@onready var ground = $ground
@onready var preview = $preview

var selected_tile : Vector2i

var select_mode : bool = false
var preview_tile : Vector2i:
	set(value):
		if preview_tile == value:
			return
		preview.erase_cell(preview_tile)
		preview_tile = value
		preview.set_cell(value, 1, selected_tile)
	

var GridSize_y = 5
var GridSize_x = 8
var Dic = {}

func _ready() -> void:
	
	
	for x in GridSize_x:
		for y in GridSize_y:
			Dic[str(Vector2(x,y))] = {
				"Type": "buildable_tile"
			}
			
			ground.set_cell(Vector2(x, y), 0, Vector2i(0,0), 0)
	print(Dic)
	
	select_mode = true
	
	
	

func snap_pos(global_pos: Vector2) -> Vector2i:
	var local_pos = ground.to_local(global_pos)
	var tile_pos = ground.local_to_map(local_pos)
	
	return tile_pos

func _process(delta: float) -> void:
	var working_space = ground.get_used_cells()
	var working_tile = get_global_mouse_position()
	if select_mode and working_space.has(snap_pos(get_global_mouse_position())):
		preview_tile = snap_pos(get_global_mouse_position())
	
