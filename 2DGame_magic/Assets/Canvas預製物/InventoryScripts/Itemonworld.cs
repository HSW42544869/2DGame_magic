using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemonworld : MonoBehaviour
{
    public Item thisItem;       //類
    public Inventory playerInventory;  //應該去到哪個背包

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))      //如果另一個物品對應上Player的Tag
        {
            AddNewItem();       //增加一個物品
            Destroy(gameObject);        //碰撞到場景中的物品後，將場景上的物品銷毀
        }
    }
    /// <summary>
    /// 新增物品
    /// </summary>
    public void AddNewItem()
    {
        if (!playerInventory.itemList.Contains(thisItem))           //如果它裡面不包含
        {
            
            for (int i = 0; i < playerInventory.itemList.Count; i++)        //判斷物件的數量如果為0且i小於物品數,i++ =>生成一個物品放置框架
            {
                if (playerInventory.itemList[i] == null)            //如果框架中沒有該物品
                {
                    playerInventory.itemList[i] = thisItem;         //新增該物品在框架中
                    break;
                }
            }
        }
        else
        {
            thisItem.itemHeld += 1;         //如果框架徵友該物品，數量加一
        }
        InventoryManager.RefreshItem();
    }
}
