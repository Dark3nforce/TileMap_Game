using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Auth;


public class FireBase : MonoBehaviour
{
    public InputField EmailAddress, Password;


    public void LoginButtonPressed()
    {
        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(EmailAddress.text, Password.text).
            ContinueWith((obj) =>
            {
                SceneManager.LoadSceneAsync("LoggedInScene");

            });

    }

    public void CreateNewUserButtonPressed()
    {
        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(EmailAddress.text, Password.text).
            ContinueWith((obj) =>
            {
                SceneManager.LoadSceneAsync("LoggedInScene");

            });
        

    }
}
