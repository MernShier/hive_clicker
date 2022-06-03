using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PUpgrades1Refresher : MonoBehaviour
{
    public GameObject Manager;
    public int ID;
    private void FixedUpdate()
    {
        if (ID == 0)
        {
            gameObject.GetComponent<Text>().text = $"You will gain:\n{ Manager.GetComponent<PrestigeUpgrades1>().OPOnPrestige1} Overseers";
        }
    }
}
