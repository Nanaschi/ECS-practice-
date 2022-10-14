using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _cubeData;
    [SerializeField] private GameObject _sphereData;

    [SerializeField] private int _amountOfCubes;

    [SerializeField] private int _rangeDistance;

    void Start()
    {
        var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        var settings =
            GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);

        var enemyEntityPrefab =
            GameObjectConversionUtility.ConvertGameObjectHierarchy(_sphereData, settings);
        
        entityManager.AddComponentData(enemyEntityPrefab, new CubeData {Speed = .1f});
        
        entityManager.Instantiate(enemyEntityPrefab);


        for (int i = 0; i < _amountOfCubes; i++)
        {
            Instantiate(_cubeData,
                new Vector3(Random.Range(-_rangeDistance, _rangeDistance), 0,
                    Random.Range(-_rangeDistance, _rangeDistance)), Quaternion.identity);
        }
    }
}