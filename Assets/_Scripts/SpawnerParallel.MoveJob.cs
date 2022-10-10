using UnityEngine;
using UnityEngine.Jobs;


    public struct MoveJob: IJobParallelForTransform
    {
        public void Execute(int index, TransformAccess transform)
        {
            transform.position += .1f * (transform.rotation * new Vector3(0,0,1));
         
            if (transform.position.z > 50)
                transform.position = 
                    new Vector3(transform.position.x, 0, -50);
        }
    }
