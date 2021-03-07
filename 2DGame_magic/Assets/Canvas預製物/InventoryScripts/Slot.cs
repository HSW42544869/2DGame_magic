using UnityEngine.UI;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public int slotID;//空格ID 等於 物品ID
    public Item slotItem;
    public Image slotImage;     //圖片變量
    public Text slotNum;        //整形的數值
    public string slotInfo;

    public GameObject itemInslot;
    /// <summary>
    /// 物品被點擊
    /// </summary>
    public void ItemOnClicked()
    {
        InventoryManager.UpdateItemInfo(slotInfo);  //將物品信息回傳給Manager
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
        slotInfo = item.iteminfo;                   //獲得字符型的物品信息
    }
}
