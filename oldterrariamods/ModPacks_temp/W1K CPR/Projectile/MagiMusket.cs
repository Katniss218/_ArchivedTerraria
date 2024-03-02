public void AI()
{
	projectile.ai[0]++;
	
	if (projectile.ai[0] >= 40)
	{
	float num48 = 14f;
	Vector2 vector8 = new Vector2(projectile.position.X, projectile.position.Y);
	int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(projectile.rotation) * num48)),(float)((Math.Sin(projectile.rotation) * num48)), 14, projectile.damage, projectile.knockBack, projectile.owner);
	projectile.Kill();
	}
}