using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarNinja : MonoBehaviour
{
    public Animator HealthBarAnimator;
    public float cur_Health = 100f;

    void Update()
    {
        HealthBarAnimator.SetFloat("Health", cur_Health);
    }
}
