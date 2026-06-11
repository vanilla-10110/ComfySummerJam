extends TileMapLayer


var GridSize_y = 5
var GridSize_x = 8
var Dic = {}

func _ready() -> void:
	
	
	for x in GridSize_x:
		for y in GridSize_y:
			Dic[str(Vector2(x,y))] = {
				"Type": "buildable_tile"
			}
			
			set_cell(Vector2(x, y), 0, Vector2i(0,0), 0)
	print(Dic)


func _process(delta: float) -> void:
	var tile = local_to_map(get_global_mouse_position())
	
	for x in GridSize_x:
		for y in GridSize_y:
			erase_cell(1, Vector2(x,y))
	
	if Dic.has(str(tile)):
		set_cell(tile, 1, Vector2i(0,0), 0)
