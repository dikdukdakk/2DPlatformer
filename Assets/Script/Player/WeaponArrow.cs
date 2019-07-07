using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponArrow : MonoBehaviour
{
    [Header("Control Arrow")]
    public Transform Arrow;
    public GameObject ArrowPrefab;
   
    void Update()
    {
        if (Input.GetButtonDown("Arrow"))
         StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        // Shooting Logic
        yield return new WaitForSeconds(0.5f);
        Instantiate(ArrowPrefab, Arrow.position, Arrow.rotation);
       
    }
}
