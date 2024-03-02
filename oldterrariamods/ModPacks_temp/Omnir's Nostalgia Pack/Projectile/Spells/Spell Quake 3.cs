#region AI
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
        projectile.frame = 4;
        return;
    }
}
#endregion

#region NPC Status
public static void StatusNPC(NPC npc) 
{
	npc.AddBuff("Free Falling", 30, false); //slows them down!
    return;
}
#endregion
