using Unity.Entities;

[GenerateAuthoringComponent]
public struct PaddleMovementData : IComponentData
{
	public int direction;
	public float speed;
}
