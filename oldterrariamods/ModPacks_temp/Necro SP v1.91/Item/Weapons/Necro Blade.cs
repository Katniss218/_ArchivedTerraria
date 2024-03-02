public static void DealtNPC(Player player, NPC npc, double damage)
{
	if (Main.rand.Next(2) == 0) //50% chance to occur
	{
		npc.AddBuff(22, 180, false);
	}
}

public void UseItemEffect(Player player, Rectangle rectangle)
{
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 54, (player.velocity.X), player.velocity.Y, 200, color, 4f);
	Main.dust[dust].noGravity = true;
}