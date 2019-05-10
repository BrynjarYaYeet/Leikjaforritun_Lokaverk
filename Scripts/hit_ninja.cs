using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// HitNinja er script til þess að finna út hvort að Ninjan hitti óvininn þegar hann lemur
// og til þess að taka health af óvininum ef það gerist



public class hit_ninja : MonoBehaviour
{
    public float Health;
    public HealthBarSponge HBS;
    public GameObject Svamp;
    // Start is called before the first frame update
    void Start()
    {
        //Hér tengjum við okkur við healthbar scriptuna hjá SpongeBob
        GameObject HealthBar = GameObject.Find("HealthBarSponge");
        HealthBarSponge HBS = HealthBar.GetComponent<HealthBarSponge>();
        Health = 100;
        Svamp.SetActive(false);
    }

    //Við settum collider á sverðið inni í animationinu þannig colliderinn er bara active þegar þú lemur
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Checkum hvort það sem þú lamdir var óvinurinn
        if (collision.gameObject.name.Equals("Player2"))
        {
            //í hvert skipti sem þú lemur hann tökum við health af og referencum Healthbar scriptuna
            Health -= 10;
            HBS.cur_Health = Health;

            // Og að sjálfssögðu þegar health er 0 þá "deyr" óvinurinn
            if (Health <= 0f)
            {
                collision.gameObject.SetActive(false);
                Svamp.SetActive(true);
            }

        }

    }
}
