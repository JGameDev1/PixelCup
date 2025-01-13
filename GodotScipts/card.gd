extends Button

var timer_To_Change_Img:float
var type_Of_Card:String
var alien_Ref:Array=["res://UI/Cards/AlienCard1.0.png", "res://UI/Cards/AlienCard1.1.png"]
var diMaria_Ref:Array=["res://UI/Cards/DiMariaLeftCard.png", "res://UI/Cards/DiMariaRightCard.png"]
var enzo_Ref:Array=["res://UI/Cards/EnzoCard.png"]
var fong_Ya_Ref:Array=["res://UI/Cards/FongYaCard.png"]
var jie_Lin_Ref:Array=["res://UI/Cards/JieLinCard0.png", "res://UI/Cards/JieLinCard1.png", "res://UI/Cards/JieLinCard2.png", "res://UI/Cards/JieLinCard3.png"]
var kuai_Liang_Ref:Array=["res://UI/Cards/KuaiLiang.png"]
var mesi_Ref:Array=["res://UI/Cards/MesiCard.png"]
var ragnar_Ref:Array=["res://UI/Cards/Ragnar2.2.png", "res://UI/Cards/RagnarCard0.png", "res://UI/Cards/RagnarCard1.png", "res://UI/Cards/RagnarCard2.png", "res://UI/Cards/RagnarCard3.png"]
var rolo_Ref:Array=["res://UI/Cards/RoloCard0.png", "res://UI/Cards/RoloCard1.png", "res://UI/Cards/RoloCard2.png", "res://UI/Cards/RoloCard3.png"]
var undead_Ref:Array=["res://UI/Cards/Skeleton0.png", "res://UI/Cards/Skeleton1.png", "res://UI/Cards/Skeleton2.png"]
var viking1_Ref:Array=["res://UI/Cards/Viking1Card2.png", "res://UI/Cards/Viking1Card3.png", "res://UI/Cards/Viking1Card.png"]
var zen_Mater1_Ref:Array=["res://UI/Cards/ZenMaster2.png", "res://UI/Cards/ZenMaster.png"]
var zen_Mater2_Ref:Array=["res://UI/Cards/ZenMaster2.1.png", "res://UI/Cards/ZenMaster2.2.png"]

func _ready() -> void:
	type_Of_Card=name
	timer_To_Change_Img=2
	match type_Of_Card:
		"alien":if GameManager.puntuation>=30:modulate=Color(1,1,1,1)
		"diMaria":if GameManager.puntuation>=60:modulate=Color(1,1,1,1)
		"enzo":if GameManager.puntuation>=90:modulate=Color(1,1,1,1)
		"fongYa":if GameManager.puntuation>=120:modulate=Color(1,1,1,1)
		"jieLin":if GameManager.puntuation>=150:modulate=Color(1,1,1,1)
		"kuaiLiang":if GameManager.puntuation>=180:modulate=Color(1,1,1,1)
		"mesi":if GameManager.puntuation>=200:modulate=Color(1,1,1,1)
		"ragnar":if GameManager.puntuation>=220:modulate=Color(1,1,1,1)
		"rolo":if GameManager.puntuation>=250:modulate=Color(1,1,1,1)
		"undead":if GameManager.puntuation>=280:modulate=Color(1,1,1,1)
		"viking":if GameManager.puntuation>=300:modulate=Color(1,1,1,1)
		"zenMaster":if GameManager.puntuation>=320:modulate=Color(1,1,1,1)
		"zenMaster2":if GameManager.puntuation>=340:modulate=Color(1,1,1,1)

func _process(delta: float) -> void:
	_visual(delta)

func _visual(frame_Rate):
	if modulate==Color(1,1,1,1):
		timer_To_Change_Img-=frame_Rate
	match type_Of_Card:
		"alien":
			if timer_To_Change_Img<=0:
				timer_To_Change_Img=0.3
				$CardImg.texture=load(alien_Ref[randi()%alien_Ref.size()])
		"diMaria":
			if timer_To_Change_Img<=0:
				timer_To_Change_Img=0.3
				$CardImg.texture=load(diMaria_Ref[randi()%diMaria_Ref.size()])
		"enzo":
			if timer_To_Change_Img<=0:
				timer_To_Change_Img=0.3
				$CardImg.texture=load(enzo_Ref[randi()%enzo_Ref.size()])
		"fongYa":
			if timer_To_Change_Img<=0:
				timer_To_Change_Img=0.3
				$CardImg.texture=load(fong_Ya_Ref[randi()%fong_Ya_Ref.size()])
		"jieLin":
			if timer_To_Change_Img<=0:
				timer_To_Change_Img=0.3
				$CardImg.texture=load(jie_Lin_Ref[randi()%jie_Lin_Ref.size()])
		"kuaiLiang":
			if timer_To_Change_Img<=0:
				timer_To_Change_Img=0.3
				$CardImg.texture=load(kuai_Liang_Ref[randi()%kuai_Liang_Ref.size()])
		"mesi":
			if timer_To_Change_Img<=0:
				timer_To_Change_Img=0.3
				$CardImg.texture=load(mesi_Ref[randi()%mesi_Ref.size()])
		"ragnar":
			if timer_To_Change_Img<=0:
				timer_To_Change_Img=0.3
				$CardImg.texture=load(ragnar_Ref[randi()%ragnar_Ref.size()])
		"rolo":
			if timer_To_Change_Img<=0:
				timer_To_Change_Img=0.3
				$CardImg.texture=load(rolo_Ref[randi()%rolo_Ref.size()])
		"undead":
			if timer_To_Change_Img<=0:
				timer_To_Change_Img=0.3
				$CardImg.texture=load(undead_Ref[randi()%undead_Ref.size()])
		"viking":
			if timer_To_Change_Img<=0:
				timer_To_Change_Img=0.3
				$CardImg.texture=load(viking1_Ref[randi()%viking1_Ref.size()])
		"zenMaster":
			if timer_To_Change_Img<=0:
				timer_To_Change_Img=0.3
				$CardImg.texture=load(zen_Mater1_Ref[randi()%zen_Mater1_Ref.size()])
		"zenMaster2":
			if timer_To_Change_Img<=0:
				timer_To_Change_Img=0.3
				$CardImg.texture=load(zen_Mater2_Ref[randi()%zen_Mater2_Ref.size()])
