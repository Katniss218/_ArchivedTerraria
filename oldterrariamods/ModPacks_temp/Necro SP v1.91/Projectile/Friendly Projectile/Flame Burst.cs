public static void StatusNPC(NPC npc) 
{
	npc.AddBuff(39, 36000, false); //cursed inferno
    return;
}

public void AI()
{
    projectile.frameCounter++;
    if (projectile.frameCounter > 3)
    {
        projectile.frame++;
        projectile.frameCounter = 0;
    }
    if (projectile.frame >= 6)
    {
        projectile.frame = 0;
        return;
    }
}