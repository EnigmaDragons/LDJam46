using UnityEngine;

[AddComponentMenu("Animation2D/Manager")]
public class Animation2DManager : MonoBehaviour {

    private Animation2D[] animations;

    private void Start()
    {
        animations = GetComponents<Animation2D>();
    }

    public void Play(string animationName, bool reverse = false, bool loop = false, bool restart = false)
    {
        foreach (Animation2D anim in animations)
        {
            if (anim.animationName == animationName)
            {
                anim.Play(reverse, loop, restart);
            }
        }
    }

    public void Pause(string animationName)
    {
        foreach (Animation2D anim in animations)
        {
            if (anim.animationName == animationName)
            {
                anim.Pause();
            }
        }
    }

    public void Resume(string animationName)
    {
        foreach (Animation2D anim in animations)
        {
            if (anim.animationName == animationName)
            {
                anim.Resume();
            }
        }
    }

    public bool isPlaying(string animationName)
    {
        foreach (Animation2D anim in animations)
        {
            if (anim.animationName == animationName)
            {
                return anim.isPlaying;
            }
        }
        return false;
    }
}
