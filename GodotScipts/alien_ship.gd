extends RayCast2D

var speed:float
var timer_To_Change_Direction:float

func _ready() -> void:
	$AnimatedSprite2D.play("default")
	speed=200
	timer_To_Change_Direction=2

func _process(delta: float) -> void:
	if timer_To_Change_Direction<=0:
		speed=-speed
		timer_To_Change_Direction=2
	timer_To_Change_Direction-=delta
	position.x+=speed*delta
	if is_colliding():
		var col_Obj=get_collider()
		if col_Obj.name=="PlayerCharacter":
			col_Obj.fading=true
