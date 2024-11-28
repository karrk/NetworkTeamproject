using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PhotonHashtable = ExitGames.Client.Photon.Hashtable;

public static class CustomProperty
{
    public const string LOAD = "Load";
    public const string READY = "Ready";
    public const string WINNER = "Winner";
    public const string LIFE = "Life";

    private static PhotonHashtable customProperty = new PhotonHashtable();

    public static void SetReady(this Player player, bool ready)
    {
        customProperty[READY] = ready;
        player.SetCustomProperties(customProperty);
    }

    public static bool GetReady(this Player player)
    {
        PhotonHashtable customProperty = player.CustomProperties;
        if (customProperty.ContainsKey(READY))
        {
            return (bool)customProperty[READY];
        }
        else
            return false;
    }

    public static void SetLoad(this Player player, bool load)
    {
        customProperty[LOAD] = load;
        player.SetCustomProperties(customProperty);
    }

    public static bool GetLoad(this Player player)
    {
        PhotonHashtable customProperty = player.CustomProperties;
        if (customProperty.ContainsKey(LOAD))
        {
            return (bool)customProperty[LOAD];
        }
        else
            return false;
    }

    public static void SetWinner(this Player player, bool number)
    {
        customProperty[WINNER] = number;
        player.SetCustomProperties(customProperty);
    }

    public static bool GetWinner(this Player player)
    {
        PhotonHashtable customProperty = player.CustomProperties;
        if (customProperty.ContainsKey(WINNER))
        {
            return (bool)customProperty[WINNER];
        }
        else
            return false;
    }

    public static void SetLife(this Player player, bool result)
    {
        customProperty[LIFE] = result;
        player.SetCustomProperties(customProperty);
    }

    public static bool GetLife(this Player player)
    {
        PhotonHashtable customProperty = player.CustomProperties;
        if (customProperty.ContainsKey(LIFE))
        {
            return (bool)customProperty[LIFE];
        }
        else
            return false;
    }
}