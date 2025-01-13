extends CharacterBody2D

func _ready() -> void:
	$AnimatedSprite2D.play("idle")

func _process(delta: float) -> void:
	if $RayCast2D.is_colliding():
		if $RayCast2D.get_collider().name=="PlayerCharacter":
			$RayCast2D.get_collider().fading=true
			$AnimatedSprite2D.play("punch")


func _on_animated_sprite_2d_animation_finished() -> void:
	$AnimatedSprite2D.play("idle")
