using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;
using Random = UnityEngine.Random;

namespace SheepECS._Scripts
{
   public class SpawnerParallel : MonoBehaviour
   {
      [SerializeField] private GameObject _sheepPrefab;
      [SerializeField] private int _spawnAmount;
      private Transform[] _sheepTransforms;
   
      [SerializeField] private float _sheepSpeed;

      private MoveJob _moveJob;
      private JobHandle _moveHandle;
      private TransformAccessArray _transforms;

      private void Start()
      {
         _sheepTransforms = new Transform[_spawnAmount];
         for (int i = 0; i < _spawnAmount; i++)
         {
            var sheep = Instantiate(_sheepPrefab, 
               new Vector3(Random.Range(-50,50),0, Random.Range(-50,50)), Quaternion.identity);
            _sheepTransforms[i] = sheep.transform;
         }

         _transforms = new TransformAccessArray(_sheepTransforms);
      }

      private void Update()
      {
         var moveJob = new MoveJob();
         _moveHandle = moveJob.Schedule(_transforms);
      }

      private void LateUpdate()
      {
         _moveHandle.Complete();
      }

      private void OldUnparallelProcess()
      {
         for (int i = 0; i < _sheepTransforms.Length; i++)
         {
            _sheepTransforms[i].transform.Translate(0, 0, _sheepSpeed);
            if (_sheepTransforms[i].transform.position.z > 50)
               _sheepTransforms[i].transform.position = new Vector3(_sheepTransforms[i].transform.position.x, 0, -50);
         }
      }

      private void OnDestroy()
      {
         _transforms.Dispose();
      }
   }
}
