using Godot;
using System;

public partial class Building : Node
{
	private Timer _attackTimer;
	
	private bool _onCooldown = false;

	[Export]
	private PackedScene _projectile = GD.Load<PackedScene>("res://Projectile_Test.tscn");
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_attackTimer = GetNode<Timer>("RayCast2D/AttackTimer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (EnemyInRange() && _attackTimer.IsStopped())
		{
			//FireLinearProjectile(_projectile);
			GD.Print("bingus");
		}
			
			
	}

	private bool EnemyInRange()
	{
		if (_onCooldown)
			return false;
		_onCooldown = true;
		return true;
	}

	private void FireLinearProjectile(PackedScene projectile)
	{
		Node instance = projectile.Instantiate();
		AddChild(instance);
		instance.global
		_attackTimer.Start();
	}
	private void FireLobbedProjectile(Node projectile, float distanceToTarget)
	{
		
	}
}
