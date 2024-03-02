#region AI
public void AI()
{
    projectile.frameCounter++;
    if (projectile.frameCounter > 3)
    {
        projectile.frame++;
        projectile.frameCounter = 0;
    }
    if (projectile.frame >= 3)
    {
        projectile.frame = 2;
        return;
    }
}
#endregion

#region NPC Status
public static void StatusNPC(NPC npc) 
{
	npc.AddBuff("Free Falling", 10, false); //slows them down!
    return;
}
#endregion
