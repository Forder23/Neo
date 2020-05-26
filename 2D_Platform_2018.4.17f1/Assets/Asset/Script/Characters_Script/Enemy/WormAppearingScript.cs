using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormAppearingScript : MonoBehaviour
{
    [SerializeField]
    private Transform LeftBoundaryPosition;
    [SerializeField]
    private Transform RightBoundaryPosition;
    [SerializeField]
    private float PositionX;
    [SerializeField]
    private static bool ChangingPosition;
    [SerializeField]
    [Range(0.0f,3.2f)]
    private float TimeToChangePosition;
    private void Start()
    {
        ChangingPosition = true;
    }
    void Update()
    {
        if (ChangingPosition == true)
        {
            PositionX = Random.Range(LeftBoundaryPosition.position.x + 2, RightBoundaryPosition.position.x - 2);
            Vector3 NewPosition = new Vector3(PositionX + 2, transform.position.y, 0.7f);
            this.transform.position = NewPosition;
            StartCoroutine(WaitForNewPosition(TimeToChangePosition));
        }
    }

    private IEnumerator WaitForNewPosition(float ChangingTime =0.5f)
    {
        ChangingPosition = false;
        yield return new WaitForSeconds(ChangingTime);
        ChangingPosition = true;
    }
}
