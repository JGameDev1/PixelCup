extends TextureRect
var lvl=preload("res://Scenes/Lvl.tscn")

func _ready() -> void:
	GameManager.state=GameManager.gameStates.pause

func _on_credits_button_pressed() -> void:
	$CreditsButton.visible=false
	$PlayButton.visible=false
	$ExitButton.visible=false
	$CreditsTxt.visible=true
	$BackButton.visible=true
	$BackButton2.visible=true
	$LanguajeButton.visible=false
	$GaleryButton.visible=false
	$"."["texture"]=load("res://UI/Buttons/Square.png")
	$TextureRect.visible=false

func _on_back_button_pressed() -> void:
	$CreditsButton.visible=true
	$PlayButton.visible=true
	$ExitButton.visible=true
	$CreditsTxt.visible=false
	$BackButton.visible=false
	$BackButton2.visible=false
	$LanguajeButton.visible=true
	$GaleryButton.visible=true
	$"."["texture"]=load("res://UI/PresentaciónFondo.png")
	$TextureRect.visible=true
	$Album.visible=false

func _on_back_button_2_pressed() -> void:
	$CreditsButton.visible=true
	$PlayButton.visible=true
	$ExitButton.visible=true
	$CreditsTxt.visible=false
	$BackButton.visible=false
	$BackButton2.visible=false
	$LanguajeButton.visible=true
	$GaleryButton.visible=true
	$"."["texture"]=load("res://UI/PresentaciónFondo.png")
	$TextureRect.visible=true
	$Album.visible=false

func _on_exit_button_pressed() -> void:
	get_tree().quit()

func _on_play_button_pressed() -> void:
	get_tree().change_scene_to_packed(lvl)

func _on_languaje_button_pressed() -> void:
	if GameManager.spanish:
		GameManager.spanish=false
		$CreditsTxt.text="Programmer, 2D artist and designer:\nJuan Ignacio López - JGameDev"
		$PlayButton.text="Play"
		$LanguajeButton.text="Languaje"
		$CreditsButton.text="Credits"
		$GaleryButton.text="Galery"
		$Album/AlbunTxt.text="Unlock the cards with points"
	else:
		GameManager.spanish=true
		$CreditsTxt.text="Programador, artista 2D y diseñador:\nJuan Ignacio López - JGameDev"
		$PlayButton.text="Jugar"
		$LanguajeButton.text="Idioma"
		$CreditsButton.text="Creditos"
		$GaleryButton.text="Galeria"
		$Album/AlbunTxt.text="Desbloquea las cartas con puntos"

func _on_galery_button_pressed() -> void:
	$CreditsButton.visible=false
	$PlayButton.visible=false
	$ExitButton.visible=false
	$CreditsTxt.visible=false
	$BackButton.visible=true
	$BackButton2.visible=true
	$LanguajeButton.visible=false
	$GaleryButton.visible=false
	$TextureRect.visible=false
	$Album.visible=true
