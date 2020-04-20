using System;
using System.Linq;
using Assets.Scripts.Demons;
using UnityEngine;
using UnityEngine.UI;

public class ParanoiaDemon : MonoBehaviour
{
    [SerializeField] private CurrentPlayerCharacter player;
    [SerializeField] private DemonState demonState;
    [SerializeField] private float freezeAngle = 90;
    [SerializeField] private float freezeDistance = 5;
    [SerializeField] private float fadeSeconds = 3;
    [SerializeField] private float secondsLookingPercent = 0.02f;
    [SerializeField] private float fadeBonusPercent = 0.06f;
    [SerializeField] private float maxedOutBonusSpeed = 7.5f;
    [SerializeField] private float accelerationMultipier = 5;
    [SerializeField] private float minSpeed = 2.5f;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private SpriteRenderer image;

    private void Awake()
    {
        Message.Subscribe<ActivateDemon>(x =>
        {
            if (x.Demon == DemonName.Paranoia)
            {
                demonState.Activate();
                transform.position = spawnPoints.Random().position;
                gameObject.SetActive(true);
            }
        }, this);
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        Message.Unsubscribe(this);
    }

    private void Update()
    {
        if (demonState.IsActive == false)
            gameObject.SetActive(false);
        if (IsPlayerLooking())
        {
            image.color = new Color(1, 1, 1, Math.Max(0, image.color.a - Time.deltaTime / fadeSeconds));
            demonState.Increment(Time.deltaTime * secondsLookingPercent);
            if (image.color.a == 0)
            {
                transform.position = spawnPoints.OrderBy(x => Rng.Dbl()).First(x => Vector2.Distance(player.PlayerCharacter.transform.position, x.position) > freezeDistance).position;
                demonState.Increment(fadeBonusPercent);
            }
        }
        else
        {
            image.color = new Color(1, 1, 1, 1f);
            var direction = Vector3.ClampMagnitude((player.PlayerCharacter.GetComponentInChildren<Collider>().transform.position - transform.position).normalized, 1);
            var speed = minSpeed + accelerationMultipier * demonState.ProgressPercent;
            if (demonState.ProgressPercent >= 1)
                speed += maxedOutBonusSpeed;
            speed *= Time.deltaTime;
            transform.position += direction * speed;
        }
        Message.Publish(new ParanoiaDistance(Vector2.Distance(transform.position, player.PlayerCharacter.transform.position)));
    }

    private bool IsPlayerLooking()
    {
        var playerLookDirection = player.PlayerCharacter.GetComponentInChildren<SpriteRenderer>().flipX 
            ? new Vector2(1, 0)
            : new Vector2(-1, 0);
        var angle = Vector2.Angle(playerLookDirection, transform.position - player.PlayerCharacter.transform.position);
        return angle < freezeAngle && Vector2.Distance(transform.position, player.PlayerCharacter.transform.position) <= freezeDistance;
    }
}