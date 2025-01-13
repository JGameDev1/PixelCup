extends CharacterBody2D
var pause_Imgs:Array=["res://UI/Mesi esperando.jpg","res://UI/Mesi esperando2.jpg"]
var win_Imgs:Array=["res://UI/DibuWin.jpg","res://UI/DiMariaWin.jpg","res://UI/MesiWin (1).jpg","res://UI/MesiWin (2).jpg","res://UI/MesiWin (3).jpg","res://UI/MesiWin (4).jpg","res://UI/MesiWin (5).jpg"]
var game_Over_Imgs:Array=["res://UI/ScaloniSad (1).jpg","res://UI/ScaloniSad (2).jpg"]
var speed:float
var normal_Speed:float
var fading_Speed:float
var points:int
var fading:bool
var fading_Timer:float
var number_Of_Fades:int
var pointsToHeal:float
var ballAmmo

func _fading(frame_Rate):
	if fading:
		fading_Timer-=frame_Rate
		if fading_Timer>0.15:
			$AnimatedSprite2D.visible=false
		elif fading_Timer<0.15 and fading_Timer>0:
			$AnimatedSprite2D.visible=true
	if fading_Timer<=0:
		fading_Timer=0.3
		number_Of_Fades+=1
	if number_Of_Fades>=4:
		fading=false
		number_Of_Fades=0
		if $GameOnCanvas/LifeRep.visible and $GameOnCanvas/LifeRep2.visible and $GameOnCanvas/LifeRep3.visible:
			$GameOnCanvas/LifeRep3.visible=false
		elif $GameOnCanvas/LifeRep.visible and $GameOnCanvas/LifeRep2.visible and !$GameOnCanvas/LifeRep3.visible:
			$GameOnCanvas/LifeRep2.visible=false
		elif $GameOnCanvas/LifeRep.visible and !$GameOnCanvas/LifeRep2.visible and !$GameOnCanvas/LifeRep3.visible:
			$GameOnCanvas/LifeRep.visible=false
			GameManager.state=GameManager.gameStates.gameOver

func _anims():
	if GameManager.state==GameManager.gameStates.pause:$AnimatedSprite2D.play("idle")
	elif GameManager.state==GameManager.gameStates.pause:$AnimatedSprite2D.play("win")

func _points_Update():
	$GameOnCanvas/PointsdRep/PointsTxt.text=String.num_int64(points)
	if points==10*pointsToHeal:
		$GameOnCanvas/LifeRep3.visible=true
		$GameOnCanvas/LifeRep2.visible=true
		$GameOnCanvas/LifeRep.visible=true
		pointsToHeal+=1.2
	if points>GameManager.puntuation:
		GameManager.puntuation=points

func movement(frame_Rate):
	$".".velocity.y+=9.8
	if GameManager.state==GameManager.gameStates.onGame and !fading:speed=normal_Speed
	elif GameManager.state==GameManager.gameStates.onGame and fading:speed=fading_Speed
	elif GameManager.state!=GameManager.gameStates.onGame:speed=0
	$".".velocity.x=speed*frame_Rate
	move_and_slide()

func _ready() -> void:
	if GameManager.puntuation==0:$GameOnCanvas/RecordTxt.visible=false
	else:$GameOnCanvas/RecordTxt.visible=true
	$GameOnCanvas/PointsdRep/PointsTxt.text=String.num_int64(points)
	$GameOnCanvas/RecordTxt.text="Record: "+String.num_int64(GameManager.puntuation)
	speed=normal_Speed
	normal_Speed=20000
	fading_Speed=10000
	number_Of_Fades=0
	fading_Timer=0.3
	fading=false
	pointsToHeal=1.2
	ballAmmo=$GameOnCanvas/BallRep
	$AnimatedSprite2D.play("run")
	GameManager.state=GameManager.gameStates.onGame
	$WinCanvas/WinImg.texture=load(win_Imgs[randi()%win_Imgs.size()])
	$GameOverCanvas/GameOverImg.texture=load(game_Over_Imgs[randi()%game_Over_Imgs.size()])
	if !GameManager.spanish:
		$PauseCanvas/ResumeButton.text="Resume"
		$PauseCanvas/BackToMenuButton.text="Menu"
		$WinCanvas/ContinueButton.text="Continue"
		$WinCanvas/BackToMenuButton.text="Menu"
		$GameOverCanvas/BackToMenuButton.text="Menu"
		$GameOverCanvas/RetryButton.text="Retry"
	else:
		$PauseCanvas/ResumeButton.text="Volver"
		$PauseCanvas/BackToMenuButton.text="Menú"
		$WinCanvas/ContinueButton.text="Continuar"
		$WinCanvas/BackToMenuButton.text="Menú"
		$GameOverCanvas/BackToMenuButton.text="Menú"
		$GameOverCanvas/RetryButton.text="Reintentar"

func _winLvl():
	if GameManager.state==GameManager.gameStates.win:
		$WinCanvas.visible=true
		$GameOnCanvas.visible=false
		$GameOverCanvas.visible=false
		$PauseCanvas.visible=false

func _gameOverLvl():
	if GameManager.state==GameManager.gameStates.gameOver:
		$GameOverCanvas.visible=true
		$GameOnCanvas.visible=false
		$WinCanvas.visible=false
		$PauseCanvas.visible=false

func _process(delta: float) -> void:
	_anims()
	_fading(delta)
	_winLvl()
	_gameOverLvl()
	if points>=400:GameManager.state=GameManager.gameStates.win

func _physics_process(delta: float) -> void:
	movement(delta)

func _on_pause_button_pressed() -> void:
	$PauseCanvas/PauseImg.texture=load(pause_Imgs[randi()%pause_Imgs.size()])
	$GameOnCanvas.visible=false
	$WinCanvas.visible=false
	$GameOverCanvas.visible=false
	$PauseCanvas.visible=true
	GameManager.state=GameManager.gameStates.pause

func _on_resume_button_pressed() -> void:
	$GameOnCanvas.visible=true
	$WinCanvas.visible=false
	$GameOverCanvas.visible=false
	$PauseCanvas.visible=false
	$AnimatedSprite2D.play("run")
	GameManager.state=GameManager.gameStates.onGame

func _on_back_to_menu_button_pressed() -> void:
	GameManager.guardar_puntuacion()
	get_tree().change_scene_to_packed(GameManager.menu_Lvl)

func _on_retry_button_pressed() -> void:
	GameManager.guardar_puntuacion()
	get_tree().change_scene_to_packed(GameManager.runner_Lvl)
	GameManager.state=GameManager.gameStates.onGame
	$".".queue_free()

func _on_continue_button_pressed() -> void:
	GameManager.guardar_puntuacion()
	get_tree().reload_current_scene()
	GameManager.state=GameManager.gameStates.onGame
	$".".queue_free()

func _on_jump_button_pressed() -> void:
	if is_on_floor():$".".velocity.y-=500

func _on_exit_button_pressed() -> void:
	get_tree().quit()

func _on_kick_button_pressed() -> void:
	if ballAmmo.visible:
		var projectile_Ball=preload("res://Scenes/Ball_Projectile.tscn").instantiate()
		projectile_Ball.global_position=global_position+Vector2(1,50)
		get_tree().root.add_child(projectile_Ball)
		ballAmmo.visible=false
		$AnimatedSprite2D.play("kick")

func _on_animated_sprite_2d_animation_finished() -> void:
	$AnimatedSprite2D.play("run")
