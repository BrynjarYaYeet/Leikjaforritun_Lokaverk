using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_sponge : MonoBehaviour
{
    public int Health;
    public HealthBarNinja HBN;
    public GameObject Ninjago;
    // Start is called before the first frame update
    void Start()
    {
        GameObject HealthBar = GameObject.Find("HealthBarNinja");
        HealthBarNinja HBN = HealthBar.GetComponent<HealthBarNinja>();


        Health = 100;
        Ninjago.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player1"))
        {
            Health -= 15;
            HBN.cur_Health = Health;

            if (Health <= 0f)
            {
                collision.gameObject.SetActive(false);
                Ninjago.SetActive(true);
            }

        }

    }
}
