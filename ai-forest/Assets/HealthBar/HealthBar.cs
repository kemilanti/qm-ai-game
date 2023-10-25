using UnityEngine;
using UnityEngine.UI; // 引入UI命名空间

public class HealthBar : MonoBehaviour
{
    public Image Bar; // 血条图像
    public float health, maxHealth = 100; // 当前血量和最大血量

    private void Start()
    {
        health = maxHealth; // 游戏开始时将当前血量设置为最大血量
        BarFiller(); // 初始设置血条填充
    }

    private void BarFiller()
    {
        Bar.fillAmount = health / maxHealth; // 更新血条填充量
    }

    public void AddHealth()
    {
        health += 10;
        if (health > maxHealth) // 确保血量不超过最大值
        {
            health = maxHealth;
        }
        BarFiller(); // 更新血条填充量
    }

    public void ReduceHealth()
    {
        health -= 10;
        if (health < 0) // 确保血量不小于0
        {
            health = 0;
        }
        BarFiller(); // 更新血条填充量
    }
}
