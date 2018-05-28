
using UnityEngine;
using PlayFab;

public static class GameFunctions
{

    public static int LOGIN_SCENE = 0;
    public static int MAIN_SCENE = 1;
    public static int GAME_SCENE = 2;
    public static int LOADING_SCENE = 3;

    public static void ChangeMenu(GameObject[] menus, int id)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            menus[i].SetActive(i == id ? true : false);
        }
    }
    
    public static void OnAPIError(PlayFabError error)
    {
        Debug.LogError(error);
    }

}
