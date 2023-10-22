using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// 移除物体
public class ItemButton : MonoBehaviour { 
    public int btnId; // 按钮id
    private Item item; // 这个按钮对应的物体

    // 获取按钮上对应的物体
    private Item GetThisItem()
    {
        for(int i=0; i<GameManager._instance.items.Count; i++)
        {
            // 按钮和itmes的索引是对应的
            if(btnId == i)
            {
                item = GameManager._instance.items[i];
            }
        }

        return item;
    }

    // 每次移除一个物体
    public void CloseBtn()
    {
        //移除
        GameManager._instance.RemoveItem(GetThisItem());
    }

    
}
