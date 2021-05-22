using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct LoginCredentials {
    public string login;
    public string password;
}

public interface ILogin {
    int TryToLogin(string login,string password);
    void updateDatabase(List<LoginCredentials> credentials);
}

[System.Serializable]
public class Login : ILogin {

    [SerializeField] private Dictionary<string, string> superSecureDatbase = new Dictionary<string, string>();
    public int TryToLogin(string login, string password) {
        string pulledPassword;
        if (superSecureDatbase.TryGetValue(login, out pulledPassword)) {
            if (pulledPassword == password) return 0;
            else return 1;
        }
        else return 1;
    }

    public void updateDatabase(List<LoginCredentials> credentials) {
        foreach (LoginCredentials c in credentials) {
            superSecureDatbase.Add(c.login,c.password);
        }
    }
}

[System.Serializable]
public class LoginProxy :  ILogin {
    private Login loginSystem;


    public LoginProxy(Login loginSystem) {
        this.loginSystem = loginSystem;
    }

    public int TryToLogin(string login, string password) {
        if (login.Length < 1 || password.Length < 1) {
            return 1;
        }
        if (loginSystem.TryToLogin(login, password)==0) {
            return 0;
        }
        else {
            return 2;
        }


    }

    public void updateDatabase(List<LoginCredentials> credentials) {
        loginSystem.updateDatabase(credentials);
    }
}
