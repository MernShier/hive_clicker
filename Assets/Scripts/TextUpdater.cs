using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;
using UnityEngine.UI;
using System;

public class TextUpdater : MonoBehaviour
{
    public GameObject biomassText;
    public double biomass, roundedmass;
    public BigInteger biomassbig;
    private void Start()
    {
        InvokeRepeating("BiomassTextUpdater", 0.05f, 0.05f);
    }
    private void FixedUpdate()
    {
        biomass = GetComponent<BiomassManager>().biomass;
        //Debug.Log(biomass.ToString("0.000E0"));
        roundedmass = Math.Round(biomass, 3);

        biomassbig = GetComponent<BiomassManager>().biomassbig;

        
        //biomassText.GetComponent<Text>().text = $"{biomass}";
        //biomassText.GetComponent<Text>().text = $"{biomassbig}";
    }
    public void BiomassTextUpdater()
    {
        if (biomass < 1000000)
        {
            biomassText.GetComponent<Text>().text = $"Biomass: {biomass.ToString("0", System.Globalization.CultureInfo.GetCultureInfo("en-US"))}";
        }
        else
        {
            biomassText.GetComponent<Text>().text = $"Biomass: {biomass.ToString("0.00e0", System.Globalization.CultureInfo.GetCultureInfo("en-US"))}";
        }
    }
}
