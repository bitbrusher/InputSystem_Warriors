﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "Device Display Configurator", menuName = "Scriptable Objects/Device Display Configurator", order = 1)]
public class DeviceDisplayConfigurator : ScriptableObject
{
    
    [System.Serializable]
    public struct DeviceSet
    {
        public string deviceRawPath;
        public DeviceDisplaySettings deviceDisplaySettings;
    }

    [System.Serializable]
    public struct DisconnectedSettings
    {
        public string disconnectedDisplayName;
        public Color disconnectedDisplayColor;
    }

    public List<DeviceSet> listDeviceSets = new List<DeviceSet>();

    public DisconnectedSettings disconnectedDeviceSettings;

    private Color fallbackDisplayColor = Color.white;


    public string GetDeviceName(PlayerInput playerInput)
    {

        string currentDeviceRawPath = playerInput.devices[0].ToString();

        string newDisplayName = null;

        for(int i = 0; i < listDeviceSets.Count; i++)
        {

            if(listDeviceSets[i].deviceRawPath == currentDeviceRawPath)
            {   
                newDisplayName = listDeviceSets[i].deviceDisplaySettings.deviceDisplayName;
            }
        }

        if(newDisplayName == null)
        {
            newDisplayName = currentDeviceRawPath;
        }

        return newDisplayName;

    }

    
    public Color GetDeviceColor(PlayerInput playerInput)
    {  

        string currentDeviceRawPath = playerInput.devices[0].ToString();
        
        Color newDisplayColor = fallbackDisplayColor;

        for(int i = 0; i < listDeviceSets.Count; i++)
        {

            if(listDeviceSets[i].deviceRawPath == currentDeviceRawPath)
            {   
                newDisplayColor = listDeviceSets[i].deviceDisplaySettings.deviceDisplayColor;
            }
        }

        return newDisplayColor;
        
    }

    public Sprite GetDeviceBindingIcon(PlayerInput playerInput, string playerInputDeviceInputBinding)
    {

        string currentDeviceRawPath = playerInput.devices[0].ToString();

        Sprite displaySpriteIcon = null;

        for(int i = 0; i < listDeviceSets.Count; i++)
        {
            if(listDeviceSets[i].deviceRawPath == currentDeviceRawPath)
            {
                if(listDeviceSets[i].deviceDisplaySettings.deviceHasContextIcons != null)
                {
                    displaySpriteIcon = FilterForDeviceInputBinding(listDeviceSets[i], playerInputDeviceInputBinding);
                }
            }
        }

        return displaySpriteIcon;
    }

    Sprite FilterForDeviceInputBinding(DeviceSet targetDeviceSet, string inputBinding)
    {
        Sprite selectedSpriteIcon = null;

        switch(inputBinding)
        {
            case "Button North":
                selectedSpriteIcon = targetDeviceSet.deviceDisplaySettings.buttonNorthIcon;  
                break;

            case "Button South":
                selectedSpriteIcon = targetDeviceSet.deviceDisplaySettings.buttonSouthIcon;
                break;

            case "Button West":
                selectedSpriteIcon = targetDeviceSet.deviceDisplaySettings.buttonWestIcon;
                break;

            case "Button East":
                selectedSpriteIcon = targetDeviceSet.deviceDisplaySettings.buttonEastIcon;
                break;

            case "Right Shoulder":
                selectedSpriteIcon = targetDeviceSet.deviceDisplaySettings.triggerRightFrontIcon;
                break;

            case "Right Trigger":
                selectedSpriteIcon = targetDeviceSet.deviceDisplaySettings.triggerRightBackIcon;
                break;

            case "rightTriggerButton":
                selectedSpriteIcon = targetDeviceSet.deviceDisplaySettings.triggerRightBackIcon;
                break;

            case "Left Shoulder":
                selectedSpriteIcon = targetDeviceSet.deviceDisplaySettings.triggerLeftFrontIcon;
                break;

            case "Left Trigger":
                selectedSpriteIcon = targetDeviceSet.deviceDisplaySettings.triggerLeftBackIcon;
                break;

            case "leftTriggerButton":
                selectedSpriteIcon = targetDeviceSet.deviceDisplaySettings.triggerLeftBackIcon;
                break;

        }

        return selectedSpriteIcon;
    }

    public string GetDisconnectedName()
    {
        return disconnectedDeviceSettings.disconnectedDisplayName;
    }

    public Color GetDisconnectedColor()
    {
        return disconnectedDeviceSettings.disconnectedDisplayColor;
    }
    
    
}