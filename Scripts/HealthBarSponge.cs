using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Þetta script heldur utan um Health hjá "Svamp Sveinsson" 
// Bara basic float breyta
// Síðan tengjum við scriptuna við Healthbar animationið til þess að sýna fyrir spilaranum að hann er að tapa health
// (Healthbarinn er bara animation)


public class HealthBarSponge : MonoBehaviour
{

    public Animator HealthBarAnimator;
    public float cur_Health = 100f;

    void Update()
    {
        HealthBarAnimator.SetFloat("Health", cur_Health);
            
     }

}
