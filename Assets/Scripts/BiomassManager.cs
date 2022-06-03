using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class BiomassManager : MonoBehaviour
{
    public GameObject[] productions;
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
    }
    public void HiveClick()
    {
            biomass += BPC + BPCfromUpgrades1;
            Debug.Log($"BPCfromUpgrades: {BPCfromUpgrades1}");
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

        if(GetComponent<PrestigeUpgrades1>().AutoClicks > 0)
        {
            biomass += ((BPC + BPCfromUpgrades1) * GetComponent<PrestigeUpgrades1>().AutoClicks) / 20;
            //Debug.Log($"Autoclicks income {((BPC + BPCfromUpgrades1) * GetComponent<PrestigeUpgrades1>().AutoClicks) / 20}");
            //Debug.Log($"BPCfromUpgrades: {BPCfromUpgrades1}");
        }
    }
}
