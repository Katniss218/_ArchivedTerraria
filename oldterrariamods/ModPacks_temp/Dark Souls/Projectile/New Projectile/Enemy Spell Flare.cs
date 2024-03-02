int customcounter=0;

#region AI
public void AI()
{
    projectile.frameCounter++;
    if (projectile.frameCounter > 3)
    {
        projectile.frame++;
        projectile.frameCounter = 0;
    }
    if ((projectile.frame >= 10) && customcounter <= 5)
    {
        projectile.frame = 6;
        customcounter += 1;
        return;
    }
    if ((projectile.frame >= 10) && customcounter >= 6)
    {
        projectile.Kill();
        return;
    }
}
#endregion