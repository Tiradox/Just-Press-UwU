using System;

public static class GlobalEventManager
{
    public static Action OnPlayerInst { get; set; }
    public static Action OnAbilityLoadad { get; set; }
    public static Action OnLocalizationLoaded { get; set; }

    public static void SendPlayerInst()
    {
        if(OnPlayerInst != null) OnPlayerInst.Invoke();
    }
    public static void SendAbilityLoadad()
    {
        if (OnAbilityLoadad != null) OnAbilityLoadad.Invoke();
    }
    public static void SendLocalizationLoaded()
    {
        if (OnLocalizationLoaded != null) OnLocalizationLoaded.Invoke();
    }
}
