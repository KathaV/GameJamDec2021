# GameJamDec2021
As titled, [Design Jam: GameJam](https://itch.io/jam/design-buddies-game-jam-2021) 2021 December form 11th to 17th

Final Electronic Submission (project): **6:59PM, 17th December**

# Project-2 README

You must modify this `README.md` that describes your application, specifically what it does, how to use it, and how you evaluated and improved it.

Remember that _"this document"_ should be `well written` and formatted **appropriately**. This is just an example of different formating tools available for you. For help with the format you can find a guide [here](https://docs.github.com/en/github/writing-on-github).


**To do:**
Basic Mechanics:
- [x] Camera Motion
- [x] Movement
- [x] Chef states
- [x] Chef Detection
For Completion:
- [ ] Incorporate Graphics (chef, potato, shelves/floor, items to hide behind)
- [ ] Animation
- [ ] Incroporate Music and Audio
- [ ] Introductory story?
- [ ] Tutorial stage/instructions
- [ ] GameOver/GameStart/Pause UI
Additional Mechanics:
- [ ] Extra power ups
- [ ] Enemies

# Table of contents
* [Team Members](#team-members)
* [Explanation of the game](#explanation-of-the-game)
* [User Interface](#user-interface)
* [Modelling Objects and Entities](#modelling-objects-and-entities)
* [Movement and Camera](#movement-and-camera)

## Team Members
* Cindy Millenia Hidajat - Dev
* Katha Villanueva - Dev
* Martin Su - Dev
* Harry Tran - Audio/Music
* Sonia Tam - Graphics

# Explanation of the game
**TODO**


# User Interface
**TODO**



# Modelling Objects and Entities
**TODO**
Will be drawn by Sonia
## Chef
* Currently, not visible. Its states are modelled by colour change such that:
    * **Green** - not looking for player/looking away
    * **Yellow** - turning towards/away from player. Potentially, can be a vulnerable stage which player movement can attract looking?
    * **Red** - Danger/Looking. If player is found like this, gameover or whatever

# Movement and Camera
As developed by Cindy:

## Camera Motion
Camera motion in this game is implemented as a third person view where the camera follows the player. The player does not need to control the camera. Hence, there would not be any pressure on the player to move the camera and character at the same time.

## Movement control : 
* Standard WASD keys are used to control movements W-Forward , A-Left, S-Backward (Towards camera), D-Right
* Space bar is used for jumping motion. Double jump can be achieved by double clicking space bar.
These movements control was chosen as they are commonly used for similar control in games.



# Contributions: 
Harry Tran: 
*

Martin Su: 
*

Katha Villanueva: 
* 

Cindy Millenia Hidajat 
* Camera control 
* Movement control 
* Menu(s) implementation- eg. pause menu, resets, game overs...

Sonia Tam: 
* Character design 

## Technologies
Project is created with:
* Unity 2021.2.6f1
