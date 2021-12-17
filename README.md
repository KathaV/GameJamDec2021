# GameJamDec2021
As titled, [Design Jam: GameJam](https://itch.io/jam/design-buddies-game-jam-2021) 2021 December from `11th to 17th`

Final Electronic Submission (project): **6:59PM, 17th December**

For help with the format you can find a guide [here](https://docs.github.com/en/github/writing-on-github).


# To-Do List:
**Basic Mechanics:**
- [x] Camera Motion
- [x] Movement
- [x] Chef states
- [x] Chef Detection

**For Completion:**
- [ ] Incorporate Graphics (chef, potato, shelves/floor, items to hide behind)
- [ ] Animation
- [ ] Incroporate Music and Audio
- [ ] Introductory story?
- [ ] Tutorial stage/instructions
- [ ] GameOver/GameStart/Pause UI

**Additional Mechanics:**
- [ ] Extra power ups
- [ ] Enemies

# Table of contents
* [Team Members](#team-members)
* [Explanation of the game](#explanation-of-the-game)
* [User Interface](#user-interface)
* [Modelling Objects and Entities](#modelling-objects-and-entities)
* [Mechanics/Physics of Objects and Entities](#mechanicsphysics-of-objects-and-entities)
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


# Settings, Components, and Scripts per Entity
## Player
Potato which user can control.
**Requirements**:
* Must be tagged `Player`
* Script Components must include: `Movement`, `Hideable`, `Key Collector` and `Stun Player` Scripts
    * **Key Collector** must have `Text(TMP)` Game Object from _Key UI_ Prefab attached, and the Message Controller prefab GameObject must be included in canvas, with the tag `MessageController`
    * **Stun Player** must have the normal Potato sprite assigned to the `Normal Image` variable and the shocked potato sprite to the `Shocked Image` variable.
* Must include RigidBody and 2D Collider

## Hideable Objects
Objects which player can hide behind when Chef is looking and avoid detection.
**Requirements**:
* 2D Collider attached, IsTrigger enabled. Collider should be resized to smaller than actual size, such that a player must be well behind the object before the collider space is triggered.
* Must be tagged `HidingPlace`
* Player requirements satisfied

# Mechanics/Physics of Objects and Entities
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
