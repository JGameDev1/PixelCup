extends Area2D

var canicas:Array=["res://Canicas/Canica.png","res://Canicas/Canica2.png","res://Canicas/Canica3.png","res://Canicas/Canica4.png","res://Canicas/Canica5.png","res://Canicas/Canica6.png","res://Canicas/Canica7.png","res://Canicas/Canica8.png","res://Canicas/Canica9.png","res://Canicas/Canica10.png","res://Canicas/Canica11.png","res://Canicas/Canica12.png","res://Canicas/Canica13.png","res://Canicas/Canica14.png","res://Canicas/Canica15.png","res://Canicas/Canica16.png","res://Canicas/Canica17.png","res://Canicas/Canica18.png"]

func _ready() -> void:
	$CanicaToShow.texture=load(canicas[randi()%canicas.size()])

func _on_body_entered(body: Node2D) -> void:
	if body.name=="PlayerCharacter":
		body.points+=1
		body._points_Update()
		queue_free()
