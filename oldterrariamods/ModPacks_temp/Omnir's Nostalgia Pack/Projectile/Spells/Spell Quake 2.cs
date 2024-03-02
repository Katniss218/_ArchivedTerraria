#region AI
public void AI()
{
    projectile.frameCounter++;
    if (projectile.frameCounter > 3)
    {
        projectile.frame++;
        projectile.frameCounter = 0;
    }
    if (projectile.frame >= 4)
    {
        projectile.frame = 3;
        return;
    }
}
#endregion

#region NPC Status
public static void StatusNPC(NPC npc) 
{
	npc.AddBuff("Free Falling", 20, false); //slows them down!
    return;
}
#endregion
