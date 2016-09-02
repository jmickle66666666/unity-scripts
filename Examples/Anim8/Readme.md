# Anim8

Anim8 is a simple sprite animation system for SpriteRenderers.

See PlayerController for an example implementation.

# Setup

Anim8 loads your sprites from Resources/ at runtime, and uses a naming scheme to 
help avoid manually typing out the filename for each sprite frame.

The structure works like this:
* Inside Resources/Sprites/, create a folder for a group of sprites eg. "Player"
* Then, in the Player/ folder, place your sprites.
* Name your frames animation_frame.ext, e.g `Run_1.png`, `Run_2.png`, `Idle_1.png`

See Resources/Sprites/Player in this repository for an example.

# Using it

Create a new Anim8 object with `Anim8 anim = new Anim8(name, spriteRenderer);`
name is the folder in which the animations for this object are stored, and spriteRenderer 
is a reference to the SpriteRenderer you want to control.

`anim = new Anim8("Player", GetComponent<SpriteRenderer>());`

Load an animation with `anim.Load(animation, speed)`
animation is the name of the animation you want to load, and speed is the speed of this
particular animation.

`anim.Load("Run",200.0f);`

Play animations simply by calling `anim.Play(name);`

`anim.Play("Run");`

Your thing should now be running!!!!!!!
