using UnityEngine;

public class EndParcur : MonoBehaviour
{
    [SerializeField] private D1SaveManager _d1SaveManager;
    [SerializeField] private GameObject _parcurObj;

    private void Awake()
    {
        if(_d1SaveManager.ParcurIsEnd)
        {
            EndParcurSave();
        }
    }

    public void EndParcurSave()
    {
        _d1SaveManager.ParcurIsEnd = true;
        _parcurObj.SetActive(false);
    }
}
