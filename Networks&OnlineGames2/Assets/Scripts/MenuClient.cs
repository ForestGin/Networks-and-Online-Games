using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuClient : MonoBehaviour
{
    public GameObject UDPClient;
    public GameObject TCPClient;

    public GameObject UDPButton;
    public GameObject TCPButton;

    public GameObject ChangeModeButton;
    public GameObject ChangeTypeButton;

    public GameObject Text;
    public GameObject TextBubble;

    public void SelectClientType(string servertype)
    {
        Debug.Log("Selecting " + servertype + "server");

        if (servertype == "UDP")
        {
            UDPClient.SetActive(true);
            TCPClient.SetActive(false);

            UDPButton.SetActive(false);
            TCPButton.SetActive(false);

            ChangeTypeButton.SetActive(true);
            ChangeModeButton.SetActive(false);

            Text.SetActive(false);
            TextBubble.SetActive(true);
        }

        if (servertype == "TCP")
        {
            UDPClient.SetActive(false);
            TCPClient.SetActive(true);

            UDPButton.SetActive(false);
            TCPButton.SetActive(false);

            ChangeTypeButton.SetActive(true);
            ChangeModeButton.SetActive(false);

            Text.SetActive(false);
            TextBubble.SetActive(true);
        }
    }

    //public void ChangeClientType()
    //{
    //    Debug.Log("Back to selecting type");

    //    UDPClient.SetActive(false);
    //    TCPClient.SetActive(false);
    //    // TODO DISCONNECT SERVERS

    //    UDPButton.SetActive(true);
    //    TCPButton.SetActive(true);

    //    ChangeTypeButton.SetActive(false);
    //    ChangeModeButton.SetActive(true);
    //}

    public void ChangeMode(string sceneName)
    {
        Debug.Log("Back to selecting mode");

        UDPClient.SetActive(false);
        TCPClient.SetActive(false);

        UDPButton.SetActive(true);
        TCPButton.SetActive(true);

        ChangeTypeButton.SetActive(false);
        ChangeModeButton.SetActive(true);

        Text.SetActive(true);
        TextBubble.SetActive(false);

        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Debug.Log("Exitting Game...");
        Application.Quit();
    }
}
