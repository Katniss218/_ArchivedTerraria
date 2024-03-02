#region AI
public void AI()
{
    projectile.frameCounter++;
    if (projectile.frameCounter > 2)
    {
        projectile.frame++;
        projectile.frameCounter = 0;
    }
    if (projectile.frame >= 4)
	{
		projectile.Kill();
        if(projectile.owner == Main.myPlayer) Projectile.NewProjectile(projectile.position.X + (float)(projectile.width / 2), projectile.position.Y + (float)(projectile.height / 2), 0, 0, "Enemy Spell Lightning 4 Bolt 3", 80, 8f, projectile.owner);
		return;
	}
}
#endregion