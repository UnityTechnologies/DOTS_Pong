using Unity.Entities;

[GenerateAuthoringComponent]
public struct SpeedIncreaseOverTimeData : IComponentData
{
	public float increasePerSecond;
}
