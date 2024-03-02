#region AI
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
        projectile.frame = 5;
        return;
    }
}
#endregion

#region NPC Status
public static void StatusNPC(NPC npc) 
{
	npc.AddBuff("Free Falling", 40, false); //slows them down!
    return;
}
#endregion
