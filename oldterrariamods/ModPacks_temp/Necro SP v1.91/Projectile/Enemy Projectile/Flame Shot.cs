public void DealtNPC(NPC npc, double damage, Player player)
{
	if (Main.rand.Next(4) == 0) //50% chance to occur
	{
		npc.AddBuff(24, 300, false);
	}
}

public void AI()
{
    projectile.frameCounter++;
    if (projectile.frameCounter > 3)
    {
        projectile.frame++;
        projectile.frameCounter = 0;
    }
    if (projectile.frame >= 5)
    {
        projectile.frame = 0;
        return;
    }
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 6, 0, 0, 100, color, 2f);
	Main.dust[dust].noGravity = true;
	if (projectile.wet)
	{
	projectile.Kill();
	}
    Rectangle projrec = new Rectangle((int)projectile.position.X+(int)projectile.velocity.X, (int)projectile.position.Y+(int)projectile.velocity.Y, projectile.width, projectile.height);
    Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player[Main.myPlayer].width,(int)Main.player[Main.myPlayer].height);

    if (projrec.Intersects(prec))
    {
    Main.player[Main.myPlayer].AddBuff(24, 300, false);
    }
}