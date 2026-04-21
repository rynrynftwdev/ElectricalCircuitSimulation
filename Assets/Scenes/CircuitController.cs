using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//Controls a two switch electrical circuit simulation.
//When both switches are ON, the bulb lights up.

public class CircuitController : MonoBehaviour
{
    //Game components
    //UI components
    [Header("UI Components")]
    public Button switch1Button;
    public Button switch2Button;
    public SpriteRenderer bulbImage;
    public TextMeshProUGUI statusText;

    //Colors
    [Header("Colors")]
    public Color bulbOnColor = Color.yellow;
    public Color bulbOffColor = Color.gray;

    //Switch states
    private bool switch1On = false;
    private bool switch2On = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCircuit();
    }

    //Called from Button #1 OnClick() Event
    public void ToggleSwtich1()
    {
        switch1On = !switch1On;
        UpdateCircuit();
    }

    //Called from Button #2 OnClick() Event
    public void ToggleSwitch2()
    {
        switch2On = !switch2On;
        UpdateCircuit();
    }

    //Evaluate the current circuit state and update visuals
    private void UpdateCircuit()
    {
        //Define a complete curcuit
        bool circuitComplete = (switch1On && switch2On);

        //Update the bulb color
        bulbImage.color = circuitComplete ? bulbOnColor : bulbOffColor;

        //Update the status message
        if (circuitComplete)
        {
            statusText.text = "Circuit Complete!";
            statusText.color = Color.green;
        }
        else
        {
            statusText.text = "Circuit Open";
            statusText.color = Color.red;
        }

        //Update Button labels
        switch1Button.GetComponentInChildren<TextMeshProUGUI>().text =
        switch1On ? "Switch 1: ON" : "Switch 1: OFF";

        switch2Button.GetComponentInChildren<TextMeshProUGUI>().text =
        switch2On ? "Switch 2: ON" : "Switch 2: OFF";
    }
}
