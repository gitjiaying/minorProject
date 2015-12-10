Neural Network level 0.0 --> Dodgy behaviour?
	
1.Save "WeightsIH.txt" & "WeightsHO.txt" in project folder
2.Open "WeightsMDF.cs" and change line 39 and line 42 to directory path of "WeightsIH.txt" & "WeightsHO.txt" respectively.
3.Open "Player_Movement_01.unity" scene in Unity Editor.
4.Drag "WeightsMDF.cs" script component unto  instance "Nerd".
5.Select "Player" rigidbody and "Nerd" rigidbody in public vars Player & Enemy (WeightsMDF.cs Script component) respectively.
5.Modify Drag and Angular drag of "Nerd" instance from infinity to low number like 2.
6.Disable Nerd's "Nav Mesh Agent" component & Nerd's "NerdsMovement.cs" Script component.
7. Press Play and see what you find!

(optional)
8. Change public var X to large number for stronger effect, or low number, as to your liking.

Note:!
PlayerMovement Should work with Forces rather than position transforms in this particular instance.