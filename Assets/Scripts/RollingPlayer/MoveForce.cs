namespace RollingDanger.RollingPlayer
{
	public record MoveForce
	{
		public MoveForce(RollForce rollForce, JumpForce jumpForce)
		{
			RollForce = rollForce.CreateClone();
			JumpForce = jumpForce.CreateClone();
		}

		public RollForce RollForce { get; }
		public JumpForce JumpForce { get; }
	}
}