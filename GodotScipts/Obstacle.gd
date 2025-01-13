extends RayCast2D

func _process(delta: float) -> void:
	if is_colliding():
		var col_Obj=get_collider()
		if col_Obj.name=="PlayerCharacter":
			col_Obj.fading=true
