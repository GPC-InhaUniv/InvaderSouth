
using UnityEngine;
using PlayFab;

public static class GameErrorManager
{

    public static void OnAPIError(PlayFabError error)
    {
        Debug.LogError(error.GetType());
        Debug.LogError(error.ErrorMessage.GetType());

    }

}
