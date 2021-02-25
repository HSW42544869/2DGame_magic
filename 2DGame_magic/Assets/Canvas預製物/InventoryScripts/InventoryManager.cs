using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;

    public Inventory myBag;
    public GameObject slotGrid;
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

    private void OnEnable()
    {
        RefreshItem();
        instance.itemInfromation.text = "";
    }

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
        newItem.slotNum.text = item.itemHeld.ToString();
    }*/

    public static void RefreshItem()
    {
        //循環刪除slotGrid下的子集物體
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            //循環刪除slotGrid下的子集物品
            if (instance.slotGrid.transform.childCount == 0)
            {
                break;
            }
            else
            {
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
