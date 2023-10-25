using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image Bar;
    public float maxHealth = 100;
    public float healthChangeAmount = 10f; // 血量变化值，可以根据需要配置
    public float lerpSpeed = 3;            // 血条平滑变化的速度

    private float _health;
    public float Health
    {
        get { return _health; }
        set
        {
            _health = Mathf.Clamp(value, 0, maxHealth); // 确保血量在 0 和 maxHealth 之间
            // 注意：我们不再直接在这里调用 BarFiller()
        }
    }

    private void Start()
    {
        Health = maxHealth;
    }

    private void Update()
    {
        BarFiller();
    }

    private void BarFiller()
    {
        // 使用 Mathf.Lerp 平滑地更新血条值
        Bar.fillAmount = Mathf.Lerp(Bar.fillAmount, Health / maxHealth, lerpSpeed * Time.deltaTime);
    }

    public void AddHealth()
    {
        Health += 10;//可调整的血量
    }

    public void ReduceHealth()
    {
        Health -= 10;
    }
}
