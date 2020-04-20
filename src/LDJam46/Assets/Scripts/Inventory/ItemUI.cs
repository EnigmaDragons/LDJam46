using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField] private Image itemImage;

    public void SetItem(Item item)
    {
        if (item == null)
        {
            Debug.LogError($"Item is Null");
            return;
        }
        itemImage.sprite = item.Sprite;
    }
}