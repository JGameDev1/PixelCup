extends CharacterBody2D

func _physics_process(delta: float) -> void:
	velocity=Vector2.RIGHT*50000*delta
	$Sprite2D.rotation_degrees+=600*delta
	move_and_slide()

func _process(delta: float) -> void:
	if $RayCast2D.is_colliding():
		$RayCast2D.get_collider().queue_free()

func _on_timer_timeout() -> void:
	queue_free()
