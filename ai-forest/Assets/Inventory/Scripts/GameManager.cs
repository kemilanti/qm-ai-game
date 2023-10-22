using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 管理游戏的核心逻辑和游戏状态
public class GameManager : MonoBehaviour
{
    // 单例 
    public static GameManager _instance;
    // 是否暂停
    public bool isPause;

    // 存储Item的列表
    public List<Item> items = new List<Item>();
    // 存储数量的列表
    public List<int> itemNumbers = new List<int>();
    // 背包的槽
    public GameObject[] slots;



    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            if(_instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        // 显示背包物体
        DisplayItems();
    }

    // 显示背包物体
    private void DisplayItems()
    {
        // 遍历所有的槽
        for(int i=0; i<slots.Length; i++)
        {
            // 有多少种物体，就显示多少
            if (i < items.Count)
            {
                // 放物体的槽,将image的透明度设置成1
                slots[i].transform.GetChild(0).GetComponent<Image>().color = Color.white;
                // 设置图片
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;
                // 设置数量
                slots[i].transform.GetChild(1).GetComponent<Text>().color = Color.white;
                slots[i].transform.GetChild(1).GetComponent<Text>().text = itemNumbers[i].ToString();
                // 如果有物体再显示右上角的×
                slots[i].transform.GetChild(2).gameObject.SetActive(true);
            }
            // 没有的要移除
            else
            {
                // 放物体的槽,将image的透明度设置成0
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1,1,1,0);
                // 设置图片为空
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                // 设置文本为空
                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = null;
                // 不显示右上角的×
                slots[i].transform.GetChild(2).gameObject.SetActive(false);
            }
        }
        
        
    }

    // 拾起物体，不知道是哪个所以加上参数
    public void AddItem(Item _item)
    {
        // 如果这个_item不在items中就添加进去
        if (!items.Contains(_item))
        {
            items.Add(_item);
            itemNumbers.Add(1);
        }
        // 在就对应的数量+1
        else
        {
            for(int i=0; i < items.Count; i++)
            {
                if(_item == items[i])
                {
                    itemNumbers[i]++;
                }
            }
            
        }
        // 显示新背包物体的信息
        DisplayItems();
    }


    public void RemoveItem(Item _item)
    {
        // 如果_item在items中
        if (items.Contains(_item))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (_item == items[i])
                {
                    itemNumbers[i]--;
                    // 如果数量为0，从items\itemNumbers移除
                    if (itemNumbers[i] == 0)
                    {
                        items.Remove(_item);
                        itemNumbers.Remove(itemNumbers[i]);
                    }
                }
            }
        }
        // 不在 else  {  }
        // 显示新背包物体的信息
        DisplayItems();
    }



}
