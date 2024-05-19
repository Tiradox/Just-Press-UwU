using UnityEngine;
using UnityEngine.UI;

public static class LayoutGroupsRefresher
{
    public static void Refresh(GameObject root)
    {
        foreach (var layoutGroup in root.GetComponentsInChildren<VerticalLayoutGroup>())
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(layoutGroup.GetComponent<RectTransform>());
        }
    }
}
