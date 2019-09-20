using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public int cubeScore;

    void Start()
    {
        StartCoroutine(JointChecker());
    }


    private IEnumerator JointChecker()
    {
        FixedJoint fixedJoint;
        bool haveJoint = true;
        while (haveJoint)
        {
            fixedJoint = this.gameObject.GetComponent<FixedJoint>();
            if (fixedJoint == null)
            {
                GameManager.Instance.AddScore(cubeScore);
                haveJoint = false;
            }

            yield return null;

        }

    }
}
