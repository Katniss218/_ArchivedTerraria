public static void DealtNPC(NPC npc, double damage, Player player)
{
	npc.AddBuff(39, 420, false);
}

public void AI()
{
    projectile.AI(true);
    int dust = Dust.NewDust(projectile.position,projectile.width,projectile.height,58,projectile.velocity.X,projectile.velocity.Y,90,new Color(),1.8f);
    Main.dust[dust].noGravity = true;
}