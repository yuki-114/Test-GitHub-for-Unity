using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGenerator : SingletonMonoBehaviour<TargetGenerator>
{
    [SerializeField] GameObject Targets;
    [SerializeField] GameObject[] TargetPrefabs;
    [SerializeField] GameObject TargetPositionObject;
    Transform[] Positions;

    GameObject newTarget;

    [SerializeField] int maxLoopCount;
    [SerializeField] float loopTime;
    [SerializeField] float loopInterval;


    int loopCount = 0;

    void Start()
    {
        Positions = TargetPositionObject.GetComponentsInChildren<Transform>();
        StartCoroutine(TargetCoroutine());
    }
    

    private IEnumerator TargetCoroutine()
    {
        while (true)
        {
            loopCount++;
            if (loopCount > maxLoopCount)
            {
                GameProcessManager.Instance.ChangeGameStatus(GameStatus.End);
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
        newTarget = Instantiate(TargetPrefabs[Random.Range(0, TargetPrefabs.Length)], newTargetPosition.position, newTargetPosition.rotation) as GameObject;
        newTarget.transform.parent = Targets.transform;

    }

    void DeleteTarget()
    {
        Destroy(newTarget);
    }
}
