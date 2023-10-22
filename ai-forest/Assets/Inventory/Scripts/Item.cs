using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 存储物体信息,继承ScriptableObject，它不会挂在物体上
[CreateAssetMenu(menuName = "Item", fileName = "New Item")]
public class Item : ScriptableObject
{
    public string itemName;//名字
    public string itemDec; //详细信息

    public Sprite itemSprite; // 物体图片
    public int itemPrice;   //物体价格
}
