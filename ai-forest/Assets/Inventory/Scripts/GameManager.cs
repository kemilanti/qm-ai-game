using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ������Ϸ�ĺ����߼�����Ϸ״̬
public class GameManager : MonoBehaviour
{
    // ���� 
    public static GameManager _instance;
    // �Ƿ���ͣ
    public bool isPause;

    // �洢Item���б�
    public List<Item> items = new List<Item>();
    // �洢�������б�
    public List<int> itemNumbers = new List<int>();
    // �����Ĳ�
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
        // ��ʾ��������
        DisplayItems();
    }

    // ��ʾ��������
    private void DisplayItems()
    {
        // �������еĲ�
        for(int i=0; i<slots.Length; i++)
        {
            // �ж��������壬����ʾ����
            if (i < items.Count)
            {
                // ������Ĳ�,��image��͸�������ó�1
                slots[i].transform.GetChild(0).GetComponent<Image>().color = Color.white;
                // ����ͼƬ
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;
                // ��������
                slots[i].transform.GetChild(1).GetComponent<Text>().color = Color.white;
                slots[i].transform.GetChild(1).GetComponent<Text>().text = itemNumbers[i].ToString();
                // �������������ʾ���Ͻǵġ�
                slots[i].transform.GetChild(2).gameObject.SetActive(true);
            }
            // û�е�Ҫ�Ƴ�
            else
            {
                // ������Ĳ�,��image��͸�������ó�0
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1,1,1,0);
                // ����ͼƬΪ��
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                // �����ı�Ϊ��
                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = null;
                // ����ʾ���Ͻǵġ�
                slots[i].transform.GetChild(2).gameObject.SetActive(false);
            }
        }
        
        
    }

    // ʰ�����壬��֪�����ĸ����Լ��ϲ���
    public void AddItem(Item _item)
    {
        // ������_item����items�о����ӽ�ȥ
        if (!items.Contains(_item))
        {
            items.Add(_item);
            itemNumbers.Add(1);
        }
        // �ھͶ�Ӧ������+1
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
        // ��ʾ�±����������Ϣ
        DisplayItems();
    }


    public void RemoveItem(Item _item)
    {
        // ���_item��items��
        if (items.Contains(_item))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (_item == items[i])
                {
                    itemNumbers[i]--;
                    // �������Ϊ0����items\itemNumbers�Ƴ�
                    if (itemNumbers[i] == 0)
                    {
                        items.Remove(_item);
                        itemNumbers.Remove(itemNumbers[i]);
                    }
                }
            }
        }
        // ���� else  {  }
        // ��ʾ�±����������Ϣ
        DisplayItems();
    }



}