using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;

public class BiomassManager : MonoBehaviour
{
    public GameObject[] productions;
    public GameObject ClickValueText, ClickValueParent, AutoClickerPosition;
    public double biomass, BPC, BPCfromUpgrades1;
    public float IncomeTimer;
    public BigInteger biomassbig;
    private void Start()
    {
        //biomass = 0;
        InvokeRepeating("ProductionTick", 0, 0.05f);
        BPC = 1;
        //biomassbig = new BigInteger(1E+3080);
    }
    private void FixedUpdate()
    {
        if (GetComponent<PrestigeUpgrades1>().BPC1 == 1)
        {
            BPCfromUpgrades1 = (GetComponent<ProductionPurchase>().TotalProduction) * 0.1;
        }
        else if (GetComponent<PrestigeUpgrades1>().BPC1 == 2)
        {
            BPCfromUpgrades1 = (GetComponent<ProductionPurchase>().TotalProduction) * 0.2;
        }
        else if (GetComponent<PrestigeUpgrades1>().BPC1 == 3)
        {
            BPCfromUpgrades1 = (GetComponent<ProductionPurchase>().TotalProduction) * 0.3;
            //Debug.Log($"BPCfromUpgrades: {BPCfromUpgrades1}");
        }
        else if (GetComponent<PrestigeUpgrades1>().BPC1 == 4)
        {
            BPCfromUpgrades1 = (GetComponent<ProductionPurchase>().TotalProduction) * 0.4;
            //Debug.Log($"BPCfromUpgrades: {BPCfromUpgrades1}");
        }
        else if (GetComponent<PrestigeUpgrades1>().BPC1 == 5)
        {
            BPCfromUpgrades1 = (GetComponent<ProductionPurchase>().TotalProduction) * 0.5;
            //Debug.Log($"BPCfromUpgrades: {BPCfromUpgrades1}");
        }
    }
    public void HiveClick()
    {
            biomass += BPC + BPCfromUpgrades1;
            Instantiate(ClickValueText, Input.mousePosition, Quaternion.identity, ClickValueParent.transform);
            //Debug.Log($"BPCfromUpgrades: {BPCfromUpgrades1}");
    }
    public void HiveAutoClickInvoke()
    {
        CancelInvoke("HiveAutoClick");
        InvokeRepeating("HiveAutoClick", (1f/GetComponent<PrestigeUpgrades1>().AutoClicks), (1f/GetComponent<PrestigeUpgrades1>().AutoClicks));
    }
    public void HiveAutoClick()
    {
        Instantiate(ClickValueText, AutoClickerPosition.GetComponent<Transform>().position, Quaternion.identity, ClickValueParent.transform);
    }
    public void ProductionTick()
    {
        biomass += (GetComponent<ProductionPurchase>().TotalProduction) / 20;
        GetComponent<ProductionPurchase>().FirstQueenAddedCount += GetComponent<ProductionPurchase>().FirstHiveTotalProduction / 20;
        GetComponent<ProductionPurchase>().FirstHiveAddedCount += GetComponent<ProductionPurchase>().SecondQueenTotalProduction / 20;
        GetComponent<ProductionPurchase>().SecondQueenAddedCount += GetComponent<ProductionPurchase>().SecondHiveTotalProduction / 20;
        GetComponent<ProductionPurchase>().SecondHiveAddedCount += GetComponent<ProductionPurchase>().ThirdQueenTotalProduction / 20;
        GetComponent<ProductionPurchase>().ThirdQueenAddedCount += GetComponent<ProductionPurchase>().ThirdHiveTotalProduction / 20;
        GetComponent<ProductionPurchase>().ThirdHiveAddedCount += GetComponent<ProductionPurchase>().FourthQueenTotalProduction / 20;
        GetComponent<ProductionPurchase>().FourthQueenAddedCount += GetComponent<ProductionPurchase>().FourthHiveTotalProduction / 20;
        GetComponent<ProductionPurchase>().FourthHiveAddedCount += GetComponent<ProductionPurchase>().FirstPrimalQueenTotalProduction / 20;

        if (GetComponent<PrestigeUpgrades1>().AutoClicks > 0)
        {
            biomass += ((BPC + BPCfromUpgrades1) * GetComponent<PrestigeUpgrades1>().AutoClicks) / 20;
            //Debug.Log($"Autoclicks income {((BPC + BPCfromUpgrades1) * GetComponent<PrestigeUpgrades1>().AutoClicks) / 20}");
            //Debug.Log($"BPCfromUpgrades: {BPCfromUpgrades1}");
        }
    }
}
