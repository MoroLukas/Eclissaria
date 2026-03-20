using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Graphics : MonoBehaviour
{
    public TMP_Dropdown ResDropDown;
    public Toggle FullScreenToggle;

    Resolution[] AllResolutions;
    List<Resolution> SelectedResolutionList = new List<Resolution>();

    int SelectedResolution;
    bool IsFullScreen;

    void Start()
    {
        AllResolutions = Screen.resolutions;
        IsFullScreen = Screen.fullScreen;

        List<string> resolutionStringList = new List<string>();

        foreach (Resolution res in AllResolutions)
        {
            string newRes = res.width + " x " + res.height;

            if (!resolutionStringList.Contains(newRes))
            {
                resolutionStringList.Add(newRes);
                SelectedResolutionList.Add(res);
            }
        }

        ResDropDown.ClearOptions();
        ResDropDown.AddOptions(resolutionStringList);

        FullScreenToggle.isOn = Screen.fullScreen;
    }

    public void ChangeResolution()
    {
        SelectedResolution = ResDropDown.value;

        Screen.SetResolution(
            SelectedResolutionList[SelectedResolution].width,
            SelectedResolutionList[SelectedResolution].height,
            IsFullScreen
        );
    }


    /*This code was made following this video:
     Master Unity Resolution Settings: How to change resolution with a DropDown
    then the code was retouched with chapgpt for a minor bug.*/
    public void ChangeFullScreen()
    {
        IsFullScreen = FullScreenToggle.isOn;

        int index = ResDropDown.value;

        if (index < 0 || index >= SelectedResolutionList.Count)
            return;

        Screen.SetResolution(
            SelectedResolutionList[index].width,
            SelectedResolutionList[index].height,
            IsFullScreen
        );
    }
}
