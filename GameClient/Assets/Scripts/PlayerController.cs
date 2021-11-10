using System;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] private GameObject chatUI = null;
    [SerializeField] private TMP_Text chatText = null;
    [SerializeField] private TMP_InputField inputField = null;

    private void FixedUpdate()
    {
        SendInputToServer();
    }

    public void HandleChatMessage(string _message)
    {
        chatText.text += _message;
    }
    public void CheckInputBoxMessage(string _message)
    {
        if (!Input.GetKeyDown(KeyCode.Return)) { return; }

        if (string.IsNullOrWhiteSpace(_message)) { return; }

        SendChatMessageToServer(_message);
    }

    public void SendChatMessageToServer(string _message)
    {
        ClientSend.ChatMessage(_message);

        inputField.text = string.Empty;
    }

    /// <summary>Sends player input to the server.</summary>
    private void SendInputToServer()
    {
        bool[] _inputs = new bool[]
        {
            Input.GetKey(KeyCode.W),
            Input.GetKey(KeyCode.S),
            Input.GetKey(KeyCode.A),
            Input.GetKey(KeyCode.D),
        };

        ClientSend.PlayerMovement(_inputs);
    }
}
