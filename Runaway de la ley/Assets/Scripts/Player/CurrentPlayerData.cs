using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPlayerData : MonoBehaviour
{
    //player data
    [HideInInspector]
    public PlayerData data;

    [Header("Asti mode modifers")]
    public float astiModePlayerVelocityUpgrade;
    public float astiModeDurationUpgrade;
    public float astiModeMultiplayerUpgrade;
    //special
    public float astiModeInvencibilityUpgrade;

    [Header("Revolvers modifiers")]
    public int ammoRevolversUpgrade;
    public float rangeRevolversUpgrade;
    public float delayRevolversUpgrade;
    public int ammoRevolverUpgradeSpecial;
    //machine gun

    [Header("Shootgun modifiers")]
    public int ammoshootgunUpgrade;
    public float rangeShootgunUpgrade;
    public float spreadShootgunUpgrade;
    public float delayShootgunUpgrade;
    public int ammoshootgunUpgradeSpecial;
    //pellets

    [Header("Throwables modifiers")]
    public int ammoThrowablesUpgrade1;
    public int ammoThrowablesUpgrade2;


    private void Awake()
    {
        //loading player data
        data = SaveSystemDataPlayer.loadPlayerData();
    }

}
