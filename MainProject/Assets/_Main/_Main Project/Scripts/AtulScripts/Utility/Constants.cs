using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerPrefKeys
{
    CharacterSeleted_INT = 0,
    LocalPlayerName_STR,
    MusicToggle_STR,
    SoundToggle_STR
}

public static class Constants
{
    public const string CharacterSeleted = "CharacterSeleted";
    public const string LocalPlayerName = "localplayerName";
    public const string MusicToggle = "MusicToggle";
    public const string SoundToggle = "SoundToggle";

    public const string Msg_CharacterSelected = "Character Selected";
}
