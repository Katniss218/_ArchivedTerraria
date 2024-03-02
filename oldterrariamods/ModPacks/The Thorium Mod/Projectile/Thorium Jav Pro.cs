
public void PreKill(){
Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1);
Dust.NewDust(projectile.position, projectile.width, projectile.height, 13, 0, 0, 0, default(Color), 1f);
Dust.NewDust(projectile.position, projectile.width, projectile.height, 13, 0, 0, 0, default(Color), 1f);
Dust.NewDust(projectile.position, projectile.width, projectile.height, 19, 0, 0, 0, default(Color), 1f);
Dust.NewDust(projectile.position, projectile.width, projectile.height, 19, 0, 0, 0, default(Color), 1f);
Dust.NewDust(projectile.position, projectile.width, projectile.height, 59, 0, 0, 0, default(Color), 1f);
Dust.NewDust(projectile.position, projectile.width, projectile.height, 59, 0, 0, 0, default(Color), 1f);
}
