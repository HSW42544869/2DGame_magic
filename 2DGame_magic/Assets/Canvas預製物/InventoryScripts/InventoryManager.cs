using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;

    public Inventory myBag;
    public GameObject slotGrid;     //格子
    //public Slot slotprefab;
    public GameObject emptyslot;
    public Text itemInfromation;

    public List<GameObject> slots = new List<GameObject>();

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
       
    }
    /// <summary>
    /// 一開始就能顯示背包裡的所有物
    /// </summary>
    private void OnEnable()
    {
        RefreshItem();
        instance.itemInfromation.text = "";
    }
    /// <summary>
    /// 傳回字符型(道具信息)
    /// </summary>
    /// <param name="itemDescription"></param>
    public static void UpdateItemInfo(string itemDescription)
    {
        instance.itemInfromation.text = itemDescription;
    }

    /*public static void CreatNewItem(Item item)
    {
        Slot newItem = Instantiate(instance.slotprefab, instance.slotGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNum.text = item.itemHeld.ToString(); //數字，用ToString改為字符型態
    }*/

    public static void RefreshItem()
    {
        //循環刪除slotGrid下的子集物體,childCount:有多少個子集
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            //循環刪除slotGrid下的子集物品
            if (instance.slotGrid.transform.childCount == 0)
            {
                break;
            }
            else
            {
                //如果不是0，則銷毀當子集下包含的物品
                Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
                instance.slots.Clear();
            }
        }
        //從新生成對應mybag裡面的物品slot
        for (int i = 0; i < instance.myBag.itemList.Count; i++)
        {
            // CreatNewItem(instance.myBag.itemList[i]);
            instance.slots.Add(Instantiate(instance.emptyslot));
            instance.slots[i].transform.SetParent(instance.slotGrid.transform);
            instance.slots[i].GetComponent<Slot>().slotID = i;
            instance.slots[i].GetComponent<Slot>().Setupslot(instance.myBag.itemList[i]);
        }
    }
}
