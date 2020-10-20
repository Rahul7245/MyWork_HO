using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInputHandlerManager : MonoBehaviour
{
    [SerializeField]
    private ManagerHandler managerHandler;
    public Button loginButton;

    private void Awake()
    {
        loginButton.onClick.AddListener(HandleLogin);
    }
    private void HandleLogin()
    {
        managerHandler.appStateManager.ToggleApp(AppState.LoginScreen, AppSubState.LoginScreen_LoginPage);
    }
}
