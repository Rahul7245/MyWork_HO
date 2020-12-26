using UnityEngine;

public static class PlayerPrefManager
{
    public static void SetPlayerPref(PlayerPrefKeys key,int val)
    {
        string intKey = "";
        switch (key)
        {
            case PlayerPrefKeys.CharacterSeleted_INT:
                intKey = Constants.CharacterSeleted;
                break;
            default:
                Debug.LogError("No Such Player Pref Available in system");
                return;
        }
        PlayerPrefs.SetInt(intKey,val);
    }
    public static void SetPlayerPref(PlayerPrefKeys key, string val)
    {
        string strKey = "";
        switch (key)
        {
            case PlayerPrefKeys.LocalPlayerName_STR:
                strKey = Constants.LocalPlayerName;
                break;
            case PlayerPrefKeys.MusicToggle_STR:
                strKey = Constants.MusicToggle;
                break;
            case PlayerPrefKeys.SoundToggle_STR:
                strKey = Constants.SoundToggle;
                break;
            default:
                Debug.LogError("No Such Player Pref Available in system");
                return;
        }
        PlayerPrefs.SetString(strKey, val);
    }
    public static int GetPlayerPrefInt(PlayerPrefKeys key, int defval)
    {
        string intKey = "";
        switch (key)
        {
            case PlayerPrefKeys.CharacterSeleted_INT:
                intKey = Constants.CharacterSeleted;
                break;
            default:
                Debug.LogError("No Such Player Pref Available in system");
                return 0;
        }
        return PlayerPrefs.GetInt(intKey, defval);
    }
    public static string GetPlayerPrefString(PlayerPrefKeys key, string defval)
    {
        string strKey = "";
        switch (key)
        {
            case PlayerPrefKeys.LocalPlayerName_STR:
                strKey = Constants.LocalPlayerName;
                break;
            case PlayerPrefKeys.MusicToggle_STR:
                strKey = Constants.MusicToggle;
                break;
            case PlayerPrefKeys.SoundToggle_STR:
                strKey = Constants.SoundToggle;
                break;
            default:
                Debug.LogError("No Such Player Pref Available in system");
                return "";
        }
        return PlayerPrefs.GetString(strKey, defval);
    }
    public static bool HasKey(PlayerPrefKeys key)
    {
        switch (key)
        {
            case PlayerPrefKeys.CharacterSeleted_INT:
                return PlayerPrefs.HasKey(Constants.CharacterSeleted);
            case PlayerPrefKeys.LocalPlayerName_STR:
                return PlayerPrefs.HasKey(Constants.LocalPlayerName);
            case PlayerPrefKeys.MusicToggle_STR:
                return PlayerPrefs.HasKey(Constants.MusicToggle);
            case PlayerPrefKeys.SoundToggle_STR:
                return PlayerPrefs.HasKey(Constants.SoundToggle);
            default:
                return false;
        }
    }
}
