extends RigidBody2D

var baloon:Array=["res://Obstacles/Baloons/BaloonBlue.png","res://Obstacles/Baloons/BaloonBrown.png","res://Obstacles/Baloons/BaloonGreen.png","res://Obstacles/Baloons/BaloonLightBlue.png","res://Obstacles/Baloons/BaloonPurple.png","res://Obstacles/Baloons/BaloonRed.png","res://Obstacles/Baloons/BaloonYellow.png"]

func _ready() -> void:
	$Sprite2D.texture=load(baloon[randi()%baloon.size()])
