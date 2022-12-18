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

[ExecuteInEditMode]
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