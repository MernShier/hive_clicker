using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickValue : MonoBehaviour
{
    public GameObject Manager;
    private void Awake()
    {
        Manager = GameObject.FindGameObjectWithTag("Manager");
        if (Manager.GetComponent<BiomassManager>().BPCfromUpgrades1<1000000)
        {
            transform.GetChild(0).GetComponent<Text>().text = $"+{(Manager.GetComponent<BiomassManager>().BPC + Manager.GetComponent<BiomassManager>().BPCfromUpgrades1).ToString("0")} Biomass";
        }
        else
        {
            transform.GetChild(0).GetComponent<Text>().text = $"+{(Manager.GetComponent<BiomassManager>().BPC + Manager.GetComponent<BiomassManager>().BPCfromUpgrades1).ToString("0.00e0")} Biomass";
        }
        Invoke("Destroy", 1f);
    }
    public void Destroy()
    {
        //Destroy(transform.GetChild(0));
        Destroy(this.gameObject);
    }
}
