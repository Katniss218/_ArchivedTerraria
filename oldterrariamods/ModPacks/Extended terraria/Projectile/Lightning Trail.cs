public void AI()
{
    projectile.alpha = 255 - (projectile.timeLeft * 2) - (int)(25 * projectile.scale);
    if (projectile.alpha < 100) projectile.alpha = 0;
}
