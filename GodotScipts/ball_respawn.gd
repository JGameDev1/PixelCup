extends Timer

func _on_timeout() -> void:
	var ball=preload("res://Scenes/Ball_Item.tscn").instantiate()
	ball.global_position.x=$"../PlayerCharacter".global_position.x+2000
	ball.global_position.y=$"../PlayerCharacter".global_position.y
	$"..".add_child(ball)
