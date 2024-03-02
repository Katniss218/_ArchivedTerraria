public void DamageNPC(NPC npc, ref int damage, ref float knockback)
{
	if (Main.rand.Next(4) == 0)
	{
		npc.AddBuff("Inferno", 540);
	}
}

public void DamagePVP(ref int damage, Player enemyPlayer)
{
	if (Main.rand.Next(4) == 0)
	{
		enemyPlayer.AddBuff(24, 540, false);
	}
}
public void PostKill()
{
	if (projectile.type == Config.projDefs.byName["Magmatic Bullet"].type && projectile.owner == Main.myPlayer)
	{
		for (int num13 = 0; num13 < 5; num13++)
		{
			float num14 = -projectile.velocity.X * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
			float num15 = -projectile.velocity.Y * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
			Projectile.NewProjectile(projectile.position.X + num14, projectile.position.Y + num15, num14, num15, Config.projDefs.byName["Magma"].type, (int)((double)projectile.damage * 0.6), 0f, projectile.owner);
		}
		projectile.active = false;
	}
	projectile.active = false;
}

public bool tileCollide(Vector2 CollideVel)
{
	Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
	projectile.ai[1] += 1f;
	if (projectile.ai[1] >= 2f)
	{
		projectile.position += projectile.velocity;
		projectile.Kill();
	}
	else
	{
		if (projectile.type == Config.projDefs.byName["Magmatic Bullet"].type && projectile.velocity.Y > 4f)
		{
			if (projectile.velocity.Y != CollideVel.Y)
			{
				projectile.velocity.Y = -CollideVel.Y * 0.8f;
			}
		}
		else
		{
			if (projectile.velocity.Y != CollideVel.Y)
			{
				projectile.velocity.Y = -CollideVel.Y;
			}
		}
		if (projectile.velocity.X != CollideVel.X)
		{
			projectile.velocity.X = -CollideVel.X;
		}
	}
	return false;
}