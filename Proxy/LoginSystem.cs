using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginSystem : MonoBehaviour
{
    [SerializeField] private TMP_InputField loginField;
    [SerializeField] private TMP_InputField passwordField;
    [SerializeField] private TextMeshProUGUI errorMessage;
    Login login;
    LoginProxy loginProxy;
    [SerializeField] private List<LoginCredentials> credentialsToUpdate;
    void Start()
    {
        login = new Login();
        loginProxy = new LoginProxy(login);
        loginProxy.updateDatabase(credentialsToUpdate);
    }

    public void LoginPressed() {
        switch (loginProxy.TryToLogin(loginField.text, passwordField.text)) {
            case 0:
                SceneManager.LoadScene("SampleScene 1", LoadSceneMode.Single);
                break;
            case 1:
                errorMessage.text = "Some fields are empty!";
                break;
            case 2:
                errorMessage.text = "Login unsuccessful, check your credentials.";
                break;
            default:
                break;
        }


    }

}
