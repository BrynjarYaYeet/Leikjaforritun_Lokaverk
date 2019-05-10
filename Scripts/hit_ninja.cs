using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_ninja : MonoBehaviour
{
    public float Health;
    public HealthBarSponge HBS;
    public GameObject Svamp;
    // Start is called before the first frame update
    void Start()
    {
        GameObject HealthBar = GameObject.Find("HealthBarSponge");
        HealthBarSponge HBS = HealthBar.GetComponent<HealthBarSponge>();
        Health = 100;
        Svamp.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player2"))
        {
            Health -= 10;
            HBS.cur_Health = Health;

            if (Health <= 0f)
            {
                collision.gameObject.SetActive(false);
                Svamp.SetActive(true);
            }

        }

    }
}
