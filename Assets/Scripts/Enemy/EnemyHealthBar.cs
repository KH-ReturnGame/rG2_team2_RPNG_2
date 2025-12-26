using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    [Tooltip("Drag the Fill RectTransform (the UI Image/RectTransform that represents the green/red bar).")]
    public RectTransform fill;

    /// <summary>
    /// Set the health bar. current and max are raw values; method clamps.
    /// </summary>
    public void SetHealth(float current, float max)
    {
        if (fill == null) return;

        float pct = 0f;
        if (max > 0f) pct = Mathf.Clamp01(current / max);
        fill.localScale = new Vector3(pct, 1f, 1f);
    }
}
