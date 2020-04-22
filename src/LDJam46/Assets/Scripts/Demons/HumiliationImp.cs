using System;
using UnityEngine;
using UnityEngine.UI;

public class HumiliationImp : MonoBehaviour
{
    [SerializeField] private CurrentPlayerCharacter player;
    [SerializeField] private float speed;
    [SerializeField] private float maxedOutSpeed = 2;
    [SerializeField] private float attractDistance;
    [SerializeField] private float fadeSeconds;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Collider collider;

    [SerializeField] private DemonState demonState;
    [SerializeField] private float percentPerSecond;

    public bool IsDying { get; set; }

    private void Update()
    {
        if (IsDying)
        {
            collider.enabled = false;
            sprite.color = new Color(1, 1, 1, Math.Max(0, sprite.color.a - Time.deltaTime / fadeSeconds));
            if (sprite.color.a == 0)
                Destroy(gameObject);
        }
        else if (!demonState.IsActive)
        {
            IsDying = true;
        }
        else if (sprite.color.a < 1)
        {
            sprite.color = new Color(1, 1, 1, Math.Min(1, sprite.color.a + Time.deltaTime / fadeSeconds));
            if (sprite.color.a == 1)
                collider.enabled = true;
        }
        else if (Vector2.Distance(transform.position, player.PlayerCharacter.transform.position) <= attractDistance)
        {
            demonState.Increment(Time.deltaTime * percentPerSecond);
            var direction = Vector3.ClampMagnitude((player.PlayerCharacter.GetComponentInChildren<Collider>().transform.position - transform.position).normalized, 1);
            var currentSpeed = demonState.ProgressPercent >= 1 ? maxedOutSpeed : this.speed;
            transform.position += direction * (currentSpeed * Time.deltaTime);
        }
        Message.Publish(new HumiliationImpDistance(Vector2.Distance(transform.position, player.PlayerCharacter.transform.position)));
    }
}