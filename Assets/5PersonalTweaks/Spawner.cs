using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject _cubeData;
    // Start is called before the first frame update
    void Start()
    {

        Instantiate(_cubeData);
        
    }
}
