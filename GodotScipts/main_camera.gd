extends Camera2D
@onready var target=$"../PlayerCharacter"
var speed:float=0.01
var x_Offset:float=350

func _process(delta: float) -> void:
	if GameManager.state==GameManager.gameStates.onGame:
		global_position.x=target.global_position.x+x_Offset
	if GameManager.state==GameManager.gameStates.gameOver:
		queue_free()
