using UnityEngine;

public class ColliderAdjust : MonoBehaviour
{
    [SerializeField] private Collider _hardCollider;
    [SerializeField] private Collider _softCollider;

    void Start()
    {
        SetHardMode(true);
    }

    private void SetHardMode(bool isHard)
    {
        _softCollider.isTrigger = isHard;
        _hardCollider.enabled = isHard;
    }

    private void OnCollisionStay(Collision collision)
    {
        CheckForTransitionToSoft(collision.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        CheckForTransitionToSoft(other.gameObject);
    }

    private void CheckForTransitionToSoft(GameObject go)
    {
        if (!enabled || !_hardCollider.enabled)
            return;

        var wheelSize = go.GetComponentInParent<WheelSize>();
        if (wheelSize != null)
        {
            if (wheelSize.Size > _hardCollider.bounds.size.y)
                SetHardMode(false);
        }
    }
}
