using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{

    public Image healthBarGO;
    public GameObject lossPanel;
    PlayerMovement playerMovement;



    private void Start()
    {
        HealthBarInitial();
        playerMovement = FindObjectOfType<PlayerMovement>();    

    }

    void HealthBarInitial()
    {
        healthBarGO.fillAmount= 1f;
        lossPanel.SetActive(false);
    }

    
    public void LoseHealth()
    {

        StartCoroutine(LoseHealth1());
        
    }


    // Need to fix this.
    public IEnumerator LoseHealth1()
    {
        if (playerMovement.fullHealth)
        {
            healthBarGO.fillAmount= 0.75f;
            yield return new WaitForSeconds(1);
            playerMovement.fullHealth= false;
            yield return new WaitForSeconds(1);
            playerMovement.threeQuarterHealth = true; 
        }
        else if (playerMovement.threeQuarterHealth)
        {
            healthBarGO.fillAmount = 0.50f;
            yield return new WaitForSeconds(1);
            playerMovement.threeQuarterHealth = false;
            yield return new WaitForSeconds(1);
            playerMovement.halfHealth = true;

        }
        else if (playerMovement.halfHealth)
        {
            healthBarGO.fillAmount = 0.25f;
            yield return new WaitForSeconds(1);
            playerMovement.halfHealth = false;
            yield return new WaitForSeconds(1);
            playerMovement.quarterHealth = true;

        }
        else if (playerMovement.quarterHealth)
        {
            healthBarGO.fillAmount = 0f;
            ChangePanel();
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(0);

        }
        yield break;
    }


    void ChangePanel()
    {
        lossPanel.SetActive(true);
        
    }

}
