using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackMainMenu : MonoBehaviour
{
    public void backClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
    }
}
