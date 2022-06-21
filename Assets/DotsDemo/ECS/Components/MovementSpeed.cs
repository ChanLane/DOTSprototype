using Unity.Entities;

namespace chandler.lane
{
    [GenerateAuthoringComponent]
    public struct MovementSpeed : IComponentData
    { 
        public float Value;
    }
}