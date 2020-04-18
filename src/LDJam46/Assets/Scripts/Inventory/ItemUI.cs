﻿using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField] private Image itemImage;

    public void SetItem(Item item)
    {
        itemImage.sprite = item.Sprite;
    }
}