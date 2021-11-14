﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSend : MonoBehaviour
{
    /// <summary>Sends a packet to the server via TCP.</summary>
    /// <param name="_packet">The packet to send to the sever.</param>
    private static void SendTCPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.tcp.SendData(_packet);
    }

    /// <summary>Sends a packet to the server via UDP.</summary>
    /// <param name="_packet">The packet to send to the sever.</param>
    private static void SendUDPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.udp.SendData(_packet);
    }

    #region Packets
    /// <summary>Lets the server know that the welcome message was received.</summary>
    public static void WelcomeReceived()
    {
        using (Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write(UIManager.instance.usernameField.text); //Sends username typed to server
            _packet.Write(GameManager.instance.RandomColor()); //Sends random color to server

            SendTCPData(_packet);
        }
    }

    public static void PlayerSpawned()
    {
        using (Packet _packet = new Packet((int)ClientPackets.playerSpawned))
        {
            _packet.Write(Client.instance.myId);

            SendTCPData(_packet);
        }
    }

    /// <summary>Sends player chat message to the server.</summary>
    /// <param name="_message"></param>
    public static void ChatMessage(string _message)
    {
        using (Packet _packet = new Packet((int)ClientPackets.chatMessage))
        {
            _packet.Write(_message);

            SendTCPData(_packet);
        }
    }

    /// <summary>Sends player input to the server.</summary>
    /// <param name="_inputs"></param>
    public static void PlayerMovement(bool[] _inputs)
    {
        using (Packet _packet = new Packet((int)ClientPackets.playerMovement))
        {
            _packet.Write(_inputs.Length);
            foreach (bool _input in _inputs)
            {
                _packet.Write(_input);
            }
            _packet.Write(GameManager.players[Client.instance.myId].transform.rotation);

            SendUDPData(_packet);
        }
    }
    #endregion
}
