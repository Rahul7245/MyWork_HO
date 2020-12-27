using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DisallowMultipleComponent]
public class LoginManager : MonoBehaviour
{
    [SerializeField]
    private ManagerHandler managerHandler;

    public void HandleLogin()
    {
        managerHandler.homeScreenManager.GoToHomeScreenHomePage();
    }
}
