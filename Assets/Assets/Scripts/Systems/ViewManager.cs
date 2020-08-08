﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : BaseManager
{
    protected override void RegisterManager() { ServiceManager.ViewManager = this; }

    [SerializeField] private BasePanel _mainMenuPanel = null;
    [SerializeField] private BasePanel _gamePlayPanel = null;

    [HideInInspector] public BasePanel CurrentActivePanel = null;

    private void Start() 
    {
        foreach(BasePanel panel in GetComponentsInChildren<BasePanel>()) 
        {
            panel.Deactivate();
        }
        _mainMenuPanel.Activate();
    }

    public void TransitToMainMenu() 
    {
        _mainMenuPanel.Activate();
    }

    public void TransitToGameplay()
    {
        _gamePlayPanel.Activate();
    }
}