using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Image healthBar;
    public GameObject lossPanel;

    private void Start()
    {
        HealthBarInitial();

    }

    void HealthBarInitial()
    {
        healthBar.fillAmount= 1f;
        lossPanel.SetActive(false);
    }

    
    // Need to fix this.
    public IEnumerator LoseHealth()
    {
        if(healthBar.fillAmount == 1f)
        {
        healthBar.fillAmount= 0.75f;
        yield return new WaitForSeconds(1);
            
        }
        else if(healthBar.fillAmount == 0.75f)
        {
            healthBar.fillAmount = 0.5f;
            yield return new WaitForSeconds(1);
            
        }
        else if (healthBar.fillAmount == 0.5f)
        {
            healthBar.fillAmount = 0.25f;
            yield return new WaitForSeconds(1);
            
        }
        else if (healthBar.fillAmount == 0.25f)
        {
            healthBar.fillAmount = 0f;
            ChangePanel();
        }
        
    }

    void ChangePanel()
    {
        lossPanel.SetActive(true);
    }

}
