extends Sprite2D

@export var wave_time = 2
# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	_ocean()
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass
	


func _ocean():
	var start_scale = global_scale.x
	var start_pos = global_position.x
	
	var tween = create_tween().set_parallel(true).set_loops()
	
	# making it so it loops foreva
	tween.set_ease(Tween.EASE_IN_OUT)
	tween.set_trans(Tween.TRANS_SINE)
	
	
	# wave be big
	tween.tween_property(self, "global_scale:x", 1.05, wave_time)
	#im sure this is a moneky way to do it but im also shifting the x position in time with the scale so it doen't just like sale in the wrong way yk?
	tween.tween_property(self, "global_position:x", 935, wave_time)
	
	# wave be small
	tween.chain().tween_property(self, "global_scale:x", start_scale, wave_time)
	tween.tween_property(self, "global_position:x", start_pos, wave_time)

	
	
