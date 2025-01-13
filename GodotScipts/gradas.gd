extends Sprite2D

var gradasImg:Array=["res://Gradas/Gradas0.png","res://Gradas/Gradas1.png","res://Gradas/Gradas2.png","res://Gradas/Gradas3.png","res://Gradas/Gradas4.png","res://Gradas/Gradas5.png"]
var Grada=preload("res://Scenes/Gradas.tscn")
var obstacles_Scenes:Array=[preload("res://Scenes/Alien_Enemy.tscn"),preload("res://Scenes/Alien_Ship.tscn"),preload("res://Scenes/Box_1.tscn"),preload("res://Scenes/Box_2.tscn"),preload("res://Scenes/Cajon.tscn"),preload("res://Scenes/Cajon.tscn"),preload("res://Scenes/Disco.tscn"),preload("res://Scenes/Maniqui.tscn"),preload("res://Scenes/Metalic_Box.tscn"),preload("res://Scenes/Rock1.tscn"),preload("res://Scenes/Rock_2.tscn"),preload("res://Scenes/vaya.tscn"),preload("res://Scenes/Cono.tscn")]
var points_Items=preload("res://Scenes/Point_Item.tscn")
var timer=0.1
var empty:bool

func _ready() -> void:
	empty=randi_range(0,1)
	var obstacle_To_Inst=obstacles_Scenes[randi()%obstacles_Scenes.size()].instantiate()
	obstacle_To_Inst.position.x=$ObstaclePos1.position.x+randi_range(-150,150)
	add_child(obstacle_To_Inst)
	var obstacle_To_Inst2=obstacles_Scenes[randi()%obstacles_Scenes.size()].instantiate()
	obstacle_To_Inst2.position.x=$ObstaclePos2.position.x+randi_range(-150,150)
	add_child(obstacle_To_Inst2)
	var obstacle_To_Inst3=obstacles_Scenes[randi()%obstacles_Scenes.size()].instantiate()
	obstacle_To_Inst3.position.x=$ObstaclePos3.position.x+randi_range(-150,150)
	add_child(obstacle_To_Inst3)
	var canica_To_Inst0=points_Items.instantiate()
	canica_To_Inst0.position.x=$PointPos0.position.x+randi_range(-100,100)
	canica_To_Inst0.position.y=$PointPos0.position.y+randi_range(-100,100)
	add_child(canica_To_Inst0)
	var canica_To_Inst1=points_Items.instantiate()
	canica_To_Inst1.position.x=$PointPos1.position.x+randi_range(-100,100)
	canica_To_Inst1.position.y=$PointPos1.position.y+randi_range(-100,100)
	add_child(canica_To_Inst1)
	var canica_To_Inst2=points_Items.instantiate()
	canica_To_Inst2.position.x=$PointPos2.position.x+randi_range(-100,100)
	canica_To_Inst2.position.y=$PointPos2.position.y+randi_range(-100,100)
	add_child(canica_To_Inst2)
	var canica_To_Inst3=points_Items.instantiate()
	canica_To_Inst3.position.x=$PointPos3.position.x+randi_range(-100,100)
	canica_To_Inst3.position.y=$PointPos3.position.y+randi_range(-100,100)
	add_child(canica_To_Inst3)
	var canica_To_Inst4=points_Items.instantiate()
	canica_To_Inst4.position.x=$PointPos4.position.x+randi_range(-100,100)
	canica_To_Inst4.position.y=$PointPos4.position.y+randi_range(-100,100)
	add_child(canica_To_Inst0)
	var canica_To_Inst5=points_Items.instantiate()
	canica_To_Inst5.position.x=$PointPos5.position.x+randi_range(-100,100)
	canica_To_Inst5.position.y=$PointPos5.position.y+randi_range(-100,100)
	add_child(canica_To_Inst5)
	var canica_To_Inst6=points_Items.instantiate()
	canica_To_Inst6.position.x=$PointPos6.position.x+randi_range(-100,100)
	canica_To_Inst6.position.y=$PointPos6.position.y+randi_range(-100,100)
	add_child(canica_To_Inst6)
	var canica_To_Inst7=points_Items.instantiate()
	canica_To_Inst7.position.x=$PointPos7.position.x+randi_range(-100,100)
	canica_To_Inst7.position.y=$PointPos7.position.y+randi_range(-100,100)
	add_child(canica_To_Inst7)

func _process(delta: float) -> void:
	timer-=delta
	if timer<=0 and !empty:
		$".".texture=load(gradasImg[randi()%gradasImg.size()])
		timer=0.1
	elif empty:
		$".".texture=load("res://Gradas/Gradas.png")
	if GameManager.state==GameManager.gameStates.gameOver:
		queue_free()

func _on_timer_timeout() -> void:
	$".".queue_free()

func _on_area_2d_body_exited(body: Node2D) -> void:
	if body.name=="PlayerCharacter":
		$Timer.start()

func _on_area_2d_body_entered(body: Node2D) -> void:
	if body.name=="PlayerCharacter":
		var inst=Grada.instantiate()
		inst.global_position=global_position+Vector2(1920,0)
		$"..".add_child(inst)
