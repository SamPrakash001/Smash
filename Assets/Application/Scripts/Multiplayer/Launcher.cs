using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;
using Random = System.Random;

public class Launcher : MonoBehaviourPunCallbacks
{
    [SerializeField] private int maxPlayers = 2;
    
  
    // Initializing the empty string 
    String randomstring = ""; 
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
    }

    private void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = maxPlayers;
        PhotonNetwork.CreateRoom(RandomString(5), roomOptions, TypedLobby.Default);
    }

    public void QuickMatch()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("joining Failed");
        CreateRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.CurrentRoom.Name);
        Debug.Log("Room Joined");
        
        PhotonNetwork.LoadLevel("smash_it");
    }
    
    
    
    private static Random random = new Random();

    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
