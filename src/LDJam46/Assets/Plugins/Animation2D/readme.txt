Animation2D - Sprite Sheet Animation Tool

--Getting started--

How to use:

We got two major scripts, Animation2D and Animation2DManager.
Animation2D is each animation, and Manager finds them in same GameObject.

Add Animation2D to GameObject with SpriteRenderer already attached, name it configure some settings
and lock the Inspector, then go to your sprite sheet, and drag all slices to Frames.

Add as many animations as you want.

then add Animation2DManager.

Now it's time to use manager to play/pause/resume animations. for that you need to make script, (example one is included)

GetCompoenent<Animation2DManager> on Awake function

and call it

Manager.Play(AnimationName, ReverseAfterFinishLoop, LoopAnimation);
Manager.Payse(AnimationName);
Manager.Resume(AnimationName);

We also included editor in Manager so with it's help it'll be easier to use.

----------

Example is included with package, the bird fly sprite sheet is royalty free, but isn't made by me, used as an Example.
For question/issue/bug or any problem feel free to contact me with Email: madfishgamesofficial@gmail.com