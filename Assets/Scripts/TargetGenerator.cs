using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGenerator : SingletonMonoBehaviour<TargetGenerator>
{
    [SerializeField] GameObject[] TargetObjects;
    [SerializeField] GameObject TargetPositionObject;
    Transform[] Positions;

    GameObject newTarget;

    [SerializeField] int maxLoopCount;
    [SerializeField] float loopTime;
    [SerializeField] float loopInterval;



    int loopCount = 0;

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
            loopCount++;
            if (loopCount > maxLoopCount)
            {
                GameManager.Instance.ChangeGameStatus(GameStatus.End);
            }

            yield return new WaitForSeconds(loopInterval);

            GenerateTarget();
            yield return new WaitForSeconds(loopTime);
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
