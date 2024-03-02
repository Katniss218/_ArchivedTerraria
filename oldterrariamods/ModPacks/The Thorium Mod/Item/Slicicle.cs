public void DamageNPC(Player player, NPC npc, ref int damage, ref float knockback)
{
	if (Main.rand.Next(5) == 0) 
	{
		npc.AddBuff("Frost", 240);
	}
}
public static void UseItemEffect(Player player, Rectangle rectangle) 
{
    Color color = new Color();
    //This is the same general effect done with the Fiery Greatsword
    int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 67, (player.velocity.X * 0.2f) + (player.direction * 3), player.velocity.Y * 0.2f, 100, color, 1.9f);
    Main.dust[dust].noGravity = true;
}