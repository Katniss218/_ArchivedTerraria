public void Effects(Player player)
{
	player.meleeDamage += 0.1f;
	int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 6, (player.velocity.X) + (player.direction * 1), player.velocity.Y, 245, Color.White, 0.6f);
	Main.dust[dust].noGravity = true;
}
public void DamageNPC (Player myPlayer, NPC npc, ref int damage, ref float knockback)
{
	if (Main.rand.Next(4) == 0)
	{
		npc.AddBuff(24, 150, false);
	}
}