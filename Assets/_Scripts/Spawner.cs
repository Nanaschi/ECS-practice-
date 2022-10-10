using UnityEngine;
public class Spawner : MonoBehaviour
{
   [SerializeField] private GameObject _sheepPrefab;
   [SerializeField] private int _spawnAmount;

   private void Start()
   {
      for (int i = 0; i < _spawnAmount; i++)
      {
         Instantiate(_sheepPrefab, 
            new Vector3(Random.Range(-50,50),0, Random.Range(-50,50)), Quaternion.identity);
      }
   }
}
