using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] TargetObjects;
    [SerializeField] GameObject TargetPositionObject;
    Transform[] Positions;

    GameObject newTarget;

    // Start is called before the first frame update
    void Start()
    {
        Positions = TargetPositionObject.GetComponentsInChildren<Transform>();
        StartCoroutine(TargetCoroutine());
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}


    private IEnumerator TargetCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            GenerateTarget();
            yield return new WaitForSeconds(2.0f);
            DeleteTarget();
        }

    }


    void GenerateTarget()
    {
        Transform newTargetPosition = Positions[Random.Range(1, Positions.Length)];
        newTarget = Instantiate(TargetObjects[Random.Range(0, TargetObjects.Length)], newTargetPosition.position, newTargetPosition.rotation) as GameObject;
        newTarget.transform.parent = this.transform;

    }

    void DeleteTarget()
    {
        Destroy(newTarget);
    }
}
