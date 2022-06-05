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
            if (Manager.GetComponent<PrestigeUpgrades1>().BiomassForOverseer < 1e281)
            {
                gameObject.GetComponent<Text>().text = $"You will gain { Manager.GetComponent<PrestigeUpgrades1>().OPOnPrestige1} Overseers\n Next on {Manager.GetComponent<PrestigeUpgrades1>().BiomassForOverseer.ToString("0e0")} Biomass";
            }
            else
            {
                gameObject.GetComponent<Text>().text = $"You will gain { Manager.GetComponent<PrestigeUpgrades1>().OPOnPrestige1} Overseers";
            }
        }
    }
}
