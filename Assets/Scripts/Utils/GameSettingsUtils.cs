using UnityEngine;

public static class GameSettingsUtils
{
    public static void SetMaximumFrameRate()
    {
#if UNITY_STANDALONE
        Application.targetFrameRate = -1;
#else
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
#endif
    }
}
