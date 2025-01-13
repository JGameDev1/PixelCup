extends Node

enum gameStates{onGame,pause,gameOver,win}
var state:gameStates
var spanish:bool
var puntuation:int
var points_To_Win:int
var menu_Lvl=preload("res://Scenes/Main_Menu.tscn")
var runner_Lvl=preload("res://Scenes/Lvl.tscn")
var archivo_guardado="user://puntuacion.dat"

func guardar_puntuacion():
	var file = FileAccess.open(archivo_guardado, FileAccess.WRITE)
	if file:
		file.store_line(str(puntuation))  # Guardamos la puntuación como texto en el archivo
		file.close()
		print("Puntuación guardada: ", puntuation)
	else:
		print("Error al guardar la puntuación.")

func cargar_puntuacion():
	if FileAccess.file_exists(archivo_guardado):
		var file = FileAccess.open(archivo_guardado, FileAccess.READ)
		if file:
			var contenido = file.get_line()  # Leemos la línea que contiene la puntuación
			puntuation = int(contenido)  # Convertimos el contenido a un número entero
			file.close()
			print("Puntuación cargada: ", puntuation)
		else:
			print("Error al abrir el archivo.")
	else:
		print("No hay puntuación guardada.")

func _ready() -> void:
	state=gameStates.onGame
	cargar_puntuacion()
	guardar_puntuacion()
