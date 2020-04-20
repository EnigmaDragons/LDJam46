using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[AddComponentMenu("Animation2D/Animation")]
[RequireComponent(typeof(SpriteRenderer))]
public class Animation2D : MonoBehaviour
{
    #region Public Variables
    [Header("General Settings")]
    public string animationName;

    [Header("Settings Properties")]

    [Tooltip("Start animating in (in seconds).")]
    [Range(0f, 1000f)]
    public float startIn;

    [Tooltip("Speed of changing frames (in seconds).")]
    [Range(0.01f, 1f)]
    public float speed;

    [Header("Autostart Settings")]

    [Tooltip("Start animation automatically on startup, no need calling from an external code.")]
    public bool automaticallyStart;

    [Tooltip("Loop of animation, if this is checked then sprite will be animated forever.")]
    public bool autoStartLoop;

    [Tooltip("Reversion of animation, if this is checked then sprite will reverse animation when it's dope first loop")]
    public bool autoStartReverse;

    [Header("Frames & Resources")]
    [Tooltip("Frames to switch in specific time interval.")]
    public Sprite[] frames;
    #endregion
    #region Public Variables (For API)
    [HideInInspector]
    public bool isPlaying = false;
    #endregion
    #region Private Variables
    private SpriteRenderer spriteRenderer;
    private ushort id;
    private bool reverse = true;
    private bool reversing = false;
    private bool loop = false;

    private bool paused = false;
    #endregion

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (automaticallyStart)
        {
            Play(autoStartReverse, autoStartLoop);
        }
    }

    private void Update()
    {
        if (isPlaying && spriteRenderer != null)
        {
            spriteRenderer.sprite = frames[id];
        }
    }

    private void PlayAnimation()
    {
        if (!paused)
        {
            isPlaying = true;

            if (reverse)
            {
                if (reversing)
                {
                    if (id > 0)
                    {
                        id--;
                    }
                    else
                    {
                        reversing = false;

                        if (!loop)
                        {
                            isPlaying = false;
                            CancelInvoke("PlayAnimation");
                        }
                    }
                }
                else
                {
                    if (id < (frames.Length - 1))
                    {
                        id++;
                    }
                    else
                    {
                        reversing = true;
                    }
                }
            }
            else
            {
                if (id < (frames.Length - 1))
                {
                    id++;
                }
                else
                {
                    if (loop)
                    {
                        id = 0;
                    }
                    else
                    {
                        isPlaying = false;
                        CancelInvoke("PlayAnimation");
                    }
                }
            }
        }
        else
        {
            isPlaying = false;
        }
    }

    public void Play(bool reverse = false, bool loop = false, bool restart = false)
    {
        paused = false;
        this.reverse = reverse;
        this.loop = loop;
	
        if (IsInvoking("PlayAnimation"))
        {
            CancelInvoke("PlayAnimation");
        }

        if (restart)
        {
            id = (ushort)0;
        }

        InvokeRepeating("PlayAnimation", startIn, speed);
    }

    public void Pause()
    {
        paused = true;
    }

    public void Resume()
    {
        paused = false;
    }
}
