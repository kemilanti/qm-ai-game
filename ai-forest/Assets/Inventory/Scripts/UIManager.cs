using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // 背包页面
    public GameObject inventoryMenu;
    // Start is called before the first frame update
    void Start()
    {
        // 背包页面刚开始是看不到的
        inventoryMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // 背包控制
        inventoryControl();
    }

    private void inventoryControl()
    {
        // 如果按下esc键，游戏正在进行，就暂停， 要是暂停状态就继续
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager._instance.isPause)
            {
                Resume();
            }
            else
            {
                Pause(); 
            }
        }
    }

    private void Pause()
    {
        // 背包界面出现
        inventoryMenu.SetActive(true);
        // 暂停游戏
        Time.timeScale = 0.0f;
        // 修改isPause的值
        GameManager._instance.isPause = true;
    }

    private void Resume()
    {
        // 背包界面隐藏
        inventoryMenu.SetActive(false);
        // 继续游戏
        Time.timeScale = 1.0f;
        // 修改isPause的值
        GameManager._instance.isPause = false;
    }
}
