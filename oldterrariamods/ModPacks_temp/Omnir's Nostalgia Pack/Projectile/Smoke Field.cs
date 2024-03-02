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
        projectile.alpha -=40;
    }
    if (projectile.frame >= 12)
    {
        projectile.Kill();
        return;
    }
}
#endregion