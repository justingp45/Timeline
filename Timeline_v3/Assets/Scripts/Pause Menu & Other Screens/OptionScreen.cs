using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class OptionScreen : UITemplate
{
    public Toggle fullscreenTog;
    public List<ResItem> resolutions = new List<ResItem>();
    private int selectedResolution;
    public TMP_Text resoltuionLabel;
    [SerializeField] private GameObject screenObject;
    protected override void CloseUIInternal(){
        screenObject.SetActive(false);
    }
    protected override void OpenUIInternal(){
        RefreshScreen();
        screenObject.SetActive(true);
    }
    void Start()
    {
        //Screen.SetResolution(resolutions[selectedResolution].horizontal,false);
        CloseUI();
    }
    private void RefreshScreen()
    {
        for (int i = 0; i < resolutions.Count; i++)
        {
            if (Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                selectedResolution = i;
                UpdateResLabel();
                break;
            }
        }
        fullscreenTog.isOn = Screen.fullScreen;
    }
    public void ResLeft()
    {
        selectedResolution--;
        if (selectedResolution < 0) selectedResolution = resolutions.Count-1;
        UpdateResLabel();
    }
    public void ResRight()
    {
        selectedResolution++;
        if (selectedResolution > resolutions.Count-1) selectedResolution=0;
        UpdateResLabel();
    }
    public void UpdateResLabel()
    {
        resoltuionLabel.text = resolutions[selectedResolution].ToString();
    }
    public void ApplyGraphics()
    {
        if (fullscreenTog.isOn) {selectedResolution = resolutions.Count-1; UpdateResLabel();}
        Screen.SetResolution(resolutions[selectedResolution].horizontal,resolutions[selectedResolution].vertical,fullscreenTog.isOn);
    }
}
[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
    public override string ToString()
    {
        return horizontal.ToString() + " x " + vertical.ToString();
    }
}