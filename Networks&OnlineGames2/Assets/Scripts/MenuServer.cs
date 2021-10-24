using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuServer : MonoBehaviour
{
    public GameObject UDPServer;
    public GameObject TCPServer;

    public GameObject UDPButton;
    public GameObject TCPButton;

    public GameObject ChangeModeButton;
    public GameObject ChangeTypeButton;

    public void SelectServerType(string servertype)
    {
        Debug.Log("Selecting " + servertype + "server");

        if (servertype == "UDP")
        {
            UDPServer.SetActive(true);
            TCPServer.SetActive(false);

            UDPButton.SetActive(false);
            TCPButton.SetActive(false);

            ChangeTypeButton.SetActive(true);
            ChangeModeButton.SetActive(false);
        }

        if (servertype == "TCP")
        {
            UDPServer.SetActive(false);
            TCPServer.SetActive(true);

            UDPButton.SetActive(false);
            TCPButton.SetActive(false);

            ChangeTypeButton.SetActive(true);
            ChangeModeButton.SetActive(false);
        }
    }

    public void ChangeServerType()
    {
        Debug.Log("Back to selecting type");

        UDPServer.SetActive(false);
        TCPServer.SetActive(false);
        // TODO DISCONNECT SERVERS

        UDPButton.SetActive(true);
        TCPButton.SetActive(true);

        ChangeTypeButton.SetActive(false);
        ChangeModeButton.SetActive(true);
    }

    public void ChangeMode(string sceneName)
    {
        Debug.Log("Back to selecting mode");

        UDPServer.SetActive(false);
        TCPServer.SetActive(false);
        // TODO DISCONNECT SERVERS

        UDPButton.SetActive(true);
        TCPButton.SetActive(true);

        ChangeTypeButton.SetActive(false);
        ChangeModeButton.SetActive(true);

        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
