using System;
using UnityEngine;

public class CharacterSortingOrder : MonoBehaviour
{
    [SerializeField] private SpriteRenderer characterBody;

    private void Update() => characterBody.sortingOrder = (int)Math.Round(characterBody.transform.localPosition.y * 100);
}