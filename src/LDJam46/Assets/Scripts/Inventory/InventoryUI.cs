using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : OnMessage<GainItem, WorldSwapPeaked>
{
    [SerializeField] private CurrentGameState state;
    [SerializeField] private Transform itemsParent;
    [SerializeField] private ItemUI itemPrefab;

    private List<ItemUI> _items = new List<ItemUI>();

    protected override void Execute(GainItem msg)
    {
        if (state.GameState.Items.Contains(msg.Item))
            return;
        state.UpdateState(x => x.Items.Add(msg.Item));
        var itemUI = Instantiate(itemPrefab, itemsParent);
        itemUI.SetItem(msg.Item);
        _items.Add(itemUI);
    }

    protected override void Execute(WorldSwapPeaked msg)
    {
        foreach (var item in _items)
            Destroy(item);
        _items.Clear();
    }
}