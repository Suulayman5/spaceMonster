using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    [SerializeField] private Slider energySlider;
    [SerializeField] private TMP_Text energyText;
 
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void UpdateEnergySlider(float current, float max)
    {
        energySlider.value = Mathf.RoundToInt(current);
        energySlider.maxValue = max;
        energyText.text = energySlider.value + "/" + energySlider.maxValue;

    }
}
