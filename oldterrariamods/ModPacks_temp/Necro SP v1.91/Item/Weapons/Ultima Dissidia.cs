public static void DealtNPC(Player player, NPC npc, double damage)
{
	player.statLife += (int)damage/10;
	//player.HealEffect((int)damage/10);
}

public static void DealtPVP(Player myPlayer, int damage, Player enemyPlayer)
{
	myPlayer.statLife += (int)(damage*2)/10;
	//myPlayer.HealEffect((int)damage/10);
}

public void UseItemEffect(Player player, Rectangle rectangle)
{
	Color color = new Color();
	if (Main.rand.Next(4)==0)
	{
	int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 25, (player.velocity.X) + (player.direction * Main.rand.Next(2, 4)), player.velocity.Y, 50, color, 1.0f);
	Main.dust[dust].noGravity = false;
	}
	Lighting.addLight((int)(rectangle.X / 16f), (int)(rectangle.Y / 16f), 0.7f, 0.2f, 0.2f);
}