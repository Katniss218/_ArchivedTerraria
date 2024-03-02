public void UseItemEffect(Player player, Rectangle rectangle)
{
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 6, (player.velocity.X * 0.2f) + (player.direction * 3), player.velocity.Y * 0.2f, 100, color, 1.9f);
	Main.dust[dust].noGravity = true;
}

public void DamageNPC (Player myPlayer, NPC npc, ref int damage, ref float knockback)
{
    if (Main.rand.Next(2) == 0)
	{
	npc.AddBuff (24, 150);
	}
}