using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SteamDrumScript : MonoBehaviour
{
    [Header("Boiler Qualities")]
    public float drumVolume;

    [Header("Initial Conditions")]
    public float waterTemperature; //Kelvin
    public float steamTemperature;
    public float drumPressure;
    public float waterQuantity; //Kilograms
    public float steamQuantity; //Kilograms
    private float waterEnergy;
    private float waterCv;
    private float boilTemperature;
    private float steamEnergy;
    private float steamCv;

    //All flows are in kilograms per timestep.
    public float flowDrumEntry; // Entrance to the drum
    public float flowDrumExit; // Exit to the drum
    public float flowDrumInput; // Drum water input
    private float drumBoiled; // Drum water evaporated

    //Energy flows are measured in kJ, specific enthalpy is measured in kJ/kg
    public float drumHeatAdded;
    public float flowDrumEntryH;
    public float flowDrumExitH;
    public float flowDrumInputH;
    public float drumBoiledH;
    private float waterEnergyflow;
    private float steamEnergyflow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        waterCv = 4.186f;
        steamCv = steamProperty.instance.FindCV(drumPressure);
        boilTemperature = steamProperty.instance.FindBoilTemp(drumPressure);

        waterTemperature = Mathf.Clamp(waterEnergy / waterQuantity * waterCv, 0.01f + 273f, boilTemperature);
        steamTemperature = Mathf.Clamp(steamEnergy / steamQuantity * steamCv, boilTemperature, 1000f + 273f);
        //Mass Balance
        waterQuantity += (flowDrumEntry + flowDrumInput - drumBoiled) * Time.deltaTime;
        steamQuantity += (drumBoiled - flowDrumExit) * Time.deltaTime;

        //Energy Balance

        waterEnergyflow = drumHeatAdded + flowDrumEntry * flowDrumEntryH - drumBoiled * drumBoiledH + flowDrumInput * flowDrumInputH;
        waterEnergy += waterEnergyflow * Time.deltaTime;


    }
}
