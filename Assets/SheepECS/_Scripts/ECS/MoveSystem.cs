using Unity.Entities;

namespace SheepECS._Scripts.ECS
{
    public partial class MoveSystem : SystemBase
    {
        /*protected override void OnUpdate()
    {
        Entities.WithName("MoveSystem").ForEach
            ((ref Translation position) =>
            {
                position.Value += .1f* math.up();
                if (position.Value.y > 100) position.Value.y = 0;
            }).Schedule();
    }*/
        protected override void OnUpdate()
        {
        
        }
    }
}
