public void UseItemEffect(Player player, Rectangle rectangle) //notes will be written to assist you further kingicarus
{
    int dust = Dust.NewDust(
    new Vector2((float) rectangle.X, (float) rectangle.Y),      //position
    rectangle.Width,                                            //box width
    rectangle.Height,                                           //box height
    58,                                                         //type
    (player.velocity.X * 0.2f) + (player.direction * 3),        //X velocity
    player.velocity.Y * 0.2f,                                   //Y velocity
    100,                                                        //alpha
    new Color(),                                                //Color override
    1.8f                                                        //scale
    );
    Main.dust[dust].noGravity = true;

    int dust2 = Dust.NewDust(
    new Vector2((float) rectangle.X, (float) rectangle.Y),      //position
    rectangle.Width,                                            //box width
    rectangle.Height,                                           //box height
    36,                                                         //type
    (player.velocity.X * 0.2f) + (player.direction * 3),        //X velocity
    player.velocity.Y * 0.2f,                                   //Y velocity
    100,                                                        //alpha
    new Color(),                                                //Color override
    1.8f                                                        //scale
    );
    Main.dust[dust2].noGravity = true;
    Main.dust[dust].OverrideTexture = Main.goreTexture[Config.goreID["Berserker Dust"]]; //Custom Dust
    Main.dust[dust].frame = new Rectangle(0,0,10,10);//(frametopleftcornerx,frametopleftcornery,framewidth,frameheight)
}
public void DamageNPC(Player player, NPC npc, ref int damage, ref float knockback)
{
	if (Main.rand.Next(18) == 0)
	{
        // Add the buff 
		npc.AddBuff("Oblivion", 120);
	}
}