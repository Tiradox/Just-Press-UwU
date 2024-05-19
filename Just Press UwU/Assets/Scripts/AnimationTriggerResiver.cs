using UnityEngine;
using UnityEngine.Events;

public class AnimationTriggerResiver : MonoBehaviour
{
    [SerializeField] private UnityEvent[] _events;

    public void InvokeFunctionByIndex(int i)
    {
        _events[i]?.Invoke();
    }
}
