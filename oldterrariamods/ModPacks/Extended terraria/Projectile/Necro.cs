public void AI()
{
    projectile.AI(true);
    int dust = Dust.NewDust(
    projectile.position,					//position
    projectile.width,                                           //box width
    projectile.height,                                          //box height
    29,                                                          //type
    projectile.velocity.X,					//X velocity
    projectile.velocity.Y,		                        //Y velocity
    60,                                                         //alpha
    new Color(),                                                //Color override
    1.8f                                                        //scale
    );
    Main.dust[dust].noGravity = true;

    projectile.rotation += 0.2f;

}
public void DamageNPC(NPC npc, ref int damage, ref float knockback)
{
	if (Main.rand.Next(5) == 0)
	{
        // Add the buff 
		npc.AddBuff("Necromancy Minus", 600);
		Main.player[Main.myPlayer].AddBuff("Necromancy Plus", 600);
	}
}