﻿using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : OnMessage<GainItem, WorldSwapPeaked, UseItem>
{
    [SerializeField] private CurrentGameState state;
    [SerializeField] private Transform itemsParent;
    [SerializeField] private ItemUI itemPrefab;

    private Dictionary<Item, ItemUI> _items = new Dictionary<Item, ItemUI>();

    protected override void Execute(GainItem msg)
    {
        if (state.GameState.Items.Contains(msg.Item))
            return;
        state.UpdateState(x => x.Items.Add(msg.Item));
        var itemUI = Instantiate(itemPrefab, itemsParent);
        itemUI.SetItem(msg.Item);
        _items[msg.Item] = itemUI;
    }

    protected override void Execute(WorldSwapPeaked msg)
    {
        foreach (var item in _items)
            Destroy(item.Value);
        _items.Clear();
    }

    protected override void Execute(UseItem msg)
    {
        state.UpdateState(x => x.Items.Remove(msg.Item));
        Destroy(_items[msg.Item]);
        _items.Remove(msg.Item);
    }
}