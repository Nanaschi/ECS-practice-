using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepLogic : MonoBehaviour
{
    [SerializeField] private float _sheepSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,_sheepSpeed);
        if (transform.position.z > 50)
            transform.position = new Vector3(Random.Range(-50, 50), 0, -50);
    }
}
