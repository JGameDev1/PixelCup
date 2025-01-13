extends Area2D

func _on_body_entered(body: Node2D) -> void:
	if body.name=="PlayerCharacter":
		body.ballAmmo.visible=true
		queue_free()
