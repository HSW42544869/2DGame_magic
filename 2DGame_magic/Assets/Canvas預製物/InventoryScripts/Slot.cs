using UnityEngine.UI;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public int slotID;//空格ID 等於 物品ID
    public Item slotItem;
    public Image slotImage;
    public Text slotNum;
    public string slotInfo;

    public GameObject itemInslot;

    public void ItemOnClicked()
    {
        InventoryManager.UpdateItemInfo(slotInfo);
    }

    public void Setupslot(Item item)
    {
        if (item == null)
        {
            itemInslot.SetActive(false);
            return;
        }

        slotImage.sprite = item.itemImage;
        slotNum.text = item.itemHeld.ToString();
        slotInfo = item.iteminfo;
    }
}
