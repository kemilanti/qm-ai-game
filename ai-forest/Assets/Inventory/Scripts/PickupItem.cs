using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 捡东西
public class PickupItem : MonoBehaviour
{
    // 特效
    public GameObject pickupEffect;
    // 物体
    public Item item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 如果是玩家碰到了
        if(collision.tag == "Player")
        {
            Instantiate(pickupEffect,transform.position, Quaternion.identity);
            GameManager._instance.AddItem(item);
            Destroy(gameObject);
        }
    }
}
