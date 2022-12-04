using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class HealthBar : MonoBehaviour
{

    public Image healthBarGO;
    PlayerMovement playerMovement;
   


    private void Start()
    {
        HealthBarInitial();
        playerMovement = FindObjectOfType<PlayerMovement>();    

    }

    void HealthBarInitial()
    {
        healthBarGO.fillAmount= 1f;
        
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
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(2);
        }
        yield break;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }


}
