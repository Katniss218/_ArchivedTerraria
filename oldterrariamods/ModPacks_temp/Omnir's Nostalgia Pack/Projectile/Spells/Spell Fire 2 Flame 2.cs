#region AI
public void AI()
{
    projectile.frameCounter++;
    if (projectile.frameCounter > 2)
    {
        projectile.frame++;
        projectile.frameCounter = 0;
    }
    if (projectile.frame >= 2)
	{
        projectile.frame = 0;
		return;
	}
	if (projectile.ai[0] == 0f)
	{
		projectile.alpha -= 50;
		if (projectile.alpha <= 0)
		{
			projectile.alpha = 0;
			projectile.ai[0] = 1f;
			if (projectile.ai[1] == 0f)
			{
				projectile.ai[1] += 1f;
				projectile.position += projectile.velocity * 1f;
			}
		}
	}
}
#endregion


