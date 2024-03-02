
public void PreKill(){
Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1);
Dust.NewDust(projectile.position, projectile.width, projectile.height, 59, 0, 0, 0, default(Color), 1f);
Dust.NewDust(projectile.position, projectile.width, projectile.height, 59, 0, 0, 0, default(Color), 1f);
Dust.NewDust(projectile.position, projectile.width, projectile.height, 59, 0, 0, 0, default(Color), 1f);
}

public void DamageNPC(NPC npc, ref int damage, ref float knockback)
{
	if (Main.rand.Next(4) == 0)
	{
		npc.AddBuff("Frost", 240);
	}
}