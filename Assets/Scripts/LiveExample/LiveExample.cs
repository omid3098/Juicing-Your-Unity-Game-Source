using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
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
    private TweenerCore<Vector3, Vector3, VectorOptions> tween;

    [Button]
    private void Move()
    {
        // transform.position = m_TargetPosition;
        tween = transform.DOMove(m_TargetPosition, 1f).SetEase(Ease.InOutSine).SetAutoKill(false);
    }

    [Button]
    private void CameraShake()
    {
        float angle = 0;
        DOTween.To(() => angle, x => angle = x, 360, 1f).OnUpdate(() =>
        {
            Debug.Log(angle);
        });
    }

    [Button]
    void Reset()
    {
        transform.DOKill(false);
        transform.position = new Vector3(-3, 0, 0);
        transform.localScale = Vector3.one;
    }
}