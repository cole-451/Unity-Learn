using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField, Tooltip("tag of object to trigger")] string tagName;
    [SerializeField] UnityEvent triggerEvent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagName))
        {
            triggerEvent.Invoke();

        }
    }
}
