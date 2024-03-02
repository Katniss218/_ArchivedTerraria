public void AI()
{
	Color color = new Color();
	int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 75, 0f, 0f, 80, color, 1.5f);
	Main.dust[dust].noGravity = true;
	projectile.AI(true);
}
public void DamageNPC(NPC npc, ref int damage, ref float knockback)
{
	if (Main.rand.Next(3) == 0)
	{
		npc.AddBuff(39, 300);
	}
}
public void DamagePVP(ref int damage, Player enemyPlayer)
{
	if (Main.rand.Next(3) == 0)
	{
		enemyPlayer.AddBuff(39, 300, false);
	}
}