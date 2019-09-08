using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : SingletonMonoBehaviour<Shooter>
{
    public GameObject cannonballPrefab;

    // Update is called once per frame
    //void Update()
    public void ShooterUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject cannonball = Instantiate(cannonballPrefab) as GameObject;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;
            cannonball.GetComponent<CannonballController>().Shoot(worldDir.normalized * 2000);
        }
    }
}
