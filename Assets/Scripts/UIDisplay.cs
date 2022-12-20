using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    public static UIDisplay UIDisplaySingleton;
    
    [SerializeField] Image chargeBarFill;

    private void Awake()
    {
        UIDisplaySingleton = this;
    }
    
    public void UpdateBar(float fillAmount)
    {
        chargeBarFill.fillAmount = fillAmount;
    }
}
