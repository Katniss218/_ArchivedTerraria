#region AI
public void AI()
{
    projectile.frameCounter++;
    if (projectile.frameCounter > 4)
    {
        projectile.frame++;
        projectile.frameCounter = 0;
    }
    if (projectile.frame >= 4)
    {
        projectile.Kill();
        return;
    }
}
#endregion