public static void DealtNPC(Player player, NPC npc, double damage)
{
	player.statLife += (int)damage/20;
}

public static void DealtPVP(Player myPlayer, int damage, Player enemyPlayer)
{
	myPlayer.statLife += (int)damage/20;
}
public void UseItemEffect(Player player, Rectangle rectangle) { 
	Color color = new Color();
    int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 54, (player.velocity.X * 0.2f) + (player.direction * 3), player.velocity.Y * 0.2f, 100, color, 1.9f);
    int dust2 = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 60, (player.velocity.X * 0.2f) + (player.direction * 3), player.velocity.Y * 0.2f, 100, color, 1.9f);
	Main.dust[dust].noGravity = true;
}