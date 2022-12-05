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
    public GameObject shield;
   


    private void Start()
    {
        HealthBarInitial();
        playerMovement = FindObjectOfType<PlayerMovement>();
        shield.SetActive(false);

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
            shield.SetActive(true);
            yield return new WaitForSeconds(1);
            playerMovement.fullHealth= false;
            yield return new WaitForSeconds(1);
            shield.SetActive(false);
            playerMovement.threeQuarterHealth = true; 
        }
        else if (playerMovement.threeQuarterHealth)
        {
            shield.SetActive(true);
            healthBarGO.fillAmount = 0.50f;
            yield return new WaitForSeconds(1);
            playerMovement.threeQuarterHealth = false;
            yield return new WaitForSeconds(1);
            shield.SetActive(false);
            playerMovement.halfHealth = true;

        }
        else if (playerMovement.halfHealth)
        {
            shield.SetActive(true);
            healthBarGO.fillAmount = 0.25f;
            yield return new WaitForSeconds(1);
            playerMovement.halfHealth = false;
            yield return new WaitForSeconds(1);
            shield.SetActive(false);
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
