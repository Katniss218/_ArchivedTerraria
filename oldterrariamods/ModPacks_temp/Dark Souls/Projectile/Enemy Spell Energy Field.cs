#region NPC Status
public static void StatusNPC(NPC npc) 
{
	npc.AddBuff(24, 36000, false); //slows them down!
    return;
}
#endregion

#region AI
public void AI()
{
    projectile.frameCounter++;
    if (projectile.frameCounter > 3)
    {
        projectile.frame++;
        projectile.frameCounter = 0;
    }
    if (projectile.frame >= 12)
    {
        projectile.frame = 0;
        return;
    }
}
#endregion