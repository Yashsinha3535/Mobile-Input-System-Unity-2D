# Mobile Input System Unity 2D
 A input system for unity game devs to implement in their 2D platformer game




Setup for the scripts:

1. There are 2 scripts: playermove and UIManager

2. Put the playermove script in ur player gameobject

3. Make an empty game object name Uimanager or GameManager etc.

4. Put the UIManager script in the empty game obejct u made

5. Make 3 btns named left, right and jump and align it accoding to ur need

6. Put those 3 buttons in the UIManager

7. In left btn and right btn, Add **Event Trigger Component** and add 2 triggers which are pointer down and pointer up 

8. In the left btn refrence in pointer down and pointer up, drag the player gameobject into it and find the mobileMove(float input) under the playermove script

9. Pointer down will have the value of -1 and pointer up will have 0 value in the left btn

10. repeat the step in right btn, and set the pointer down value to 1 instead of -1 and the up value will be 0

11. Now u are good to go

