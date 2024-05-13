using UnityEngine;
using UnityEngine.Events;

public class AnimationTriggerResiver : MonoBehaviour
{
    [SerializeField] private UnityEvent[] _events;

    private void Invoke(int i)
    {
        if(_events[i] != null)
        {
            _events[i].Invoke();
        }
    }
}
