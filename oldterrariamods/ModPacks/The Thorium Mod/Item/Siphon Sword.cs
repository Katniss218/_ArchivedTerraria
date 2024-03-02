public void DealtNPC(Player player, NPC npc, double damage)
{
	player.statMana += (int)damage/5;
}

public void DealtPVP(Player myPlayer, int damage, Player enemyPlayer)
{
	myPlayer.statMana += (int)(damage*2)/5;
}

public static void UseItemEffect(Player player, Rectangle rectangle) 
{
    Color color = new Color();
    //This is the same general effect done with the Fiery Greatsword
    int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 14, (player.velocity.X * 0.2f) + (player.direction * 3), player.velocity.Y * 0.2f, 100, color, 1.9f);
    Main.dust[dust].noGravity = true;
}
