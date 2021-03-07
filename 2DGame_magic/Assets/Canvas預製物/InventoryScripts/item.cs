using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item")]  //創建Item選項
public class Item :ScriptableObject
{
    public string itemName;         //物品名子
    public Sprite itemImage;        //物品圖片
    public int itemHeld;            //物品整形變量
    [TextArea]  //可使信息量增加，將信息變為文本框
    public string iteminfo;         //物品資訊

    public bool equip;              //可被裝備的
}
