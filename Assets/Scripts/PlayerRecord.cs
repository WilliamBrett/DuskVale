using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRecord : MonoBehaviour
{
    private PlayerController ControllerRef;
    private HealthManager HealthRef;
    public bool DJUnlocked;
    public bool DashUnlocked;
    public bool WJUnlocked;
    public int MaxHP;

    public void SetupRecord(bool DJ, bool Dash, bool WJ, int Max)
    {
        this.DJUnlocked = DJ;
        this.DashUnlocked = Dash;
        this.WJUnlocked = WJ;
        this.MaxHP = Max;
        ControllerRef = this.GetComponentInParent<PlayerController>();
        HealthRef = this.GetComponentInParent<HealthManager>();
        SetData();
    }
    
    public void SetData()
    {
        ControllerRef.DJUnlocked = DJUnlocked;
        ControllerRef.DashUnlocked = DashUnlocked;
        ControllerRef.WJUnlocked = WJUnlocked;
        HealthRef.maxhealth = MaxHP;
    }

}
