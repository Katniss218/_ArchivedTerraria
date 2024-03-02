public static void DealtNPC(NPC npc, double damage, Player player)
{
	npc.AddBuff(39, 420, false);
	npc.AddBuff(36, 840, false);
}

public void UseItemEffect(Player player, Rectangle rectangle)
{
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 60, 0, 0, 100, color, 2f);
	Main.dust[dust].noGravity = true;
}