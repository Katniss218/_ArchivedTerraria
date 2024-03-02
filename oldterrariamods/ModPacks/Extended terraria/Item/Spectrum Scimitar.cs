public void UseItemEffect(Player player, Rectangle rectangle) //notes will be written to assist you further kingicarus
{
    int dust = Dust.NewDust(
    new Vector2((float) rectangle.X, (float) rectangle.Y),      //position
    rectangle.Width,                                            //box width
    rectangle.Height,                                           //box height
    57,                                                         //type
    (player.velocity.X * 0.2f) + (player.direction * 3),        //X velocity
    player.velocity.Y * 0.2f,                                   //Y velocity
    100,                                                        //alpha
    new Color(),                                                //Color override
    1.8f                                                        //scale
    );
    Main.dust[dust].noGravity = true;
}
public void DamageNPC(Player player, NPC npc, ref int damage, ref float knockback)
{
	if (Main.rand.Next(7) == 0) 
	{
        // Add the buff 
		npc.AddBuff(31, 180);
	}
}
public void DamagePVP(ref int damage, Player enemyPlayer)
{
	if (Main.rand.Next(7) == 0) 
	{
        // Add the buff 
		enemyPlayer.AddBuff(31, 240, false);
	}
}