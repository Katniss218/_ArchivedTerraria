#region AI
public void AI()
{
    projectile.frameCounter++;
    if (projectile.frameCounter > 2)
    {
        projectile.frame++;
        projectile.frameCounter = 0;
    }
    if (projectile.frame >= 12)
	{
		projectile.Kill();
		return;
	}
}
#endregion
