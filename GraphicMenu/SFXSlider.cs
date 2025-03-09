using UnityEngine;
using UnityEngine.UI;

public class VFXControl : MonoBehaviour
{
    public Slider vfxSlider;
    public GameObject lowVFX;
    public GameObject mediumVFX;
    public GameObject highVFX;

    void Start()
    {
        vfxSlider.onValueChanged.AddListener(delegate { SetVFXLevel(); });
        vfxSlider.value = PlayerPrefs.GetInt("VFXLevel", 1);
        SetVFXLevel();
    }

    public void SetVFXLevel()
    {
        int vfxLevel = (int)vfxSlider.value;
        PlayerPrefs.SetInt("VFXLevel", vfxLevel);

        switch (vfxLevel)
        {
            case 0:
                lowVFX.SetActive(true);
                mediumVFX.SetActive(false);
                highVFX.SetActive(false);
                break;
            case 1:
                lowVFX.SetActive(false);
                mediumVFX.SetActive(true);
                highVFX.SetActive(false);
                break;
            case 2:
                lowVFX.SetActive(false);
                mediumVFX.SetActive(false);
                highVFX.SetActive(true);
                break;
        }
    }
}
