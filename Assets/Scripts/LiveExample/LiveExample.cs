using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

// Move
// EaseTypes and Animation curve
// Loops and LoopType (-1 = Infinite)
// Delay
// Scale
// OnComplete callback
// Backwards (.SetAutoKill(false))
// Shake (good values for a small camera shake: DOShakePosition(0.2f, 0.2f, 100, 45, false))
// Int/Float:
// float angle = 0;
// DOTween.To(() => angle, x => angle = x, 360, 1f);

public class LiveExample : MonoBehaviour
{
    [SerializeField] Vector3 m_TargetPosition = new Vector3(3, 0, 0);

    [Button]
    private void Move()
    {
        // transform.position = m_TargetPosition;
        transform.DOMove(m_TargetPosition, 1f);

    }

    [Button]
    void Reset()
    {
        transform.DOKill(false);
        transform.position = new Vector3(-3, 0, 0);
        transform.localScale = Vector3.one;
    }
}