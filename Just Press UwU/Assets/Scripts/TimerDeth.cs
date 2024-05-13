using UnityEngine;

public class TimerDeth : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 3f);
    }
}
