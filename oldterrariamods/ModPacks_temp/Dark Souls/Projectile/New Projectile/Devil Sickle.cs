public void AI()
{
    projectile.AI(true);
    int dust = Dust.NewDust(
    projectile.position,					//position
    projectile.width,                                           //box width
    projectile.height,                                          //box height
    6,                                                          //type
    projectile.velocity.X,					//X velocity
    projectile.velocity.Y,		                        //Y velocity
    90,                                                         //alpha
    new Color(),                                                //Color override
    1.8f                                                        //scale
    );
    Main.dust[dust].noGravity = true;

    //projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);

    //projectile.direction = Main.player[projectile.owner].direction;
    projectile.rotation += (float)projectile.direction * 0.8f;

    if (projectile.velocity.X <= 7f && projectile.velocity.Y <= 7f && projectile.velocity.X >= -7f && projectile.velocity.Y >= -7f)
    {
	projectile.velocity.X *= 1.06f;
	projectile.velocity.Y *= 1.06f;
    }
}
public void DamageNPC(NPC npc, ref int damage, ref float knockback)
{
	if (Main.rand.Next(5) == 0) 
	{
        // Add the buff 
		npc.AddBuff(24, 420);
	}
}
public void DamagePVP(ref int damage, Player enemyPlayer)
{
	if (Main.rand.Next(5) == 0) 
	{
        // Add the buff 
		enemyPlayer.AddBuff(24, 420, false);
	}
}