﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class RoomListPanel : BasePanel
{
    [SerializeField] private RoomItem _roomItem = null;
    [SerializeField] private ScrollRect _roomScroll = null;
    private List<RoomItem> _roomItemList = new List<RoomItem>();

    private void Start() 
    {
        // Destroy any existing children in scroll rect
        foreach(GameObject child in _roomScroll.content.transform) 
        {
            Destroy(child);
        }
    }

    protected override void OnActive()
    {
        UpdateRooms();
    }

    public void UpdateRooms()
    {
        ClearRooms();
        IEnumerable<RoomInfo> rooms = ServiceManager.RoomManager.GetRooms();
        int i = 0;
        foreach(RoomInfo room in rooms) 
        {
            i++;
            if ( i < _roomItemList.Count)
            {
                _roomItemList[i].Initialize(room.Name, room.PlayerCount, room.MaxPlayers, "TODO");
            }
            else 
            {
                RoomItem roomItem = Instantiate(_roomItem, _roomScroll.content);
                roomItem.Initialize(room.Name, room.PlayerCount, room.MaxPlayers, "TODO");
                _roomItemList.Add(roomItem);
            }
        }
    }

    private void ClearRooms()
    {
        foreach (RoomItem roomitem in _roomItemList)
        {
            roomitem.gameObject.SetActive(false);
        }
    }

}
