using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.Jobs;

public class SpawnerParallel : MonoBehaviour
{
   [SerializeField] private GameObject _sheepPrefab;
   [SerializeField] private int _spawnAmount;
   private GameObject[] _sheepList;
   
   [SerializeField] private float _sheepSpeed;
   private void Start()
   {
      _sheepList = new GameObject[_spawnAmount];
      for (int i = 0; i < _spawnAmount; i++)
      {
          _sheepList[i] = Instantiate(_sheepPrefab, 
            new Vector3(Random.Range(-50,50),0, Random.Range(-50,50)), Quaternion.identity);
      }
   }

   private void Update()
   {
      for (int i = 0; i < _sheepList.Length; i++)
      {
         _sheepList[i].transform.Translate(0,0,_sheepSpeed);
         if (_sheepList[i].transform.position.z > 50)
            _sheepList[i].transform.position = 
               new Vector3(_sheepList[i].transform.position.x, 0, -50);
      }
   }
}
