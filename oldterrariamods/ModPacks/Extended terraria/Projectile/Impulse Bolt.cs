public void AI()
{
    Projectile P = projectile;
    Player O = Main.player[P.owner];
    if (projectile.scale == 1.0){
        projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
        if (Main.time % 6 <= 1) {
            int num54 = Projectile.NewProjectile(projectile.position.X, projectile.position.Y,0,0,"Impulse Trail",10,0f,projectile.owner);
            Main.projectile[num54].rotation = projectile.rotation;
            Main.projectile[num54].timeLeft = projectile.timeLeft;
            projectile.rotation = (P.ai[1] == 0 ? (P.rotation + (Main.rand.Next(100)-50)/100f) : P.ai[1]);
	    P.ai[1] = P.rotation;
            projectile.velocity.Y = (float)Math.Sin(projectile.rotation)*10;
            projectile.velocity.X = (float)Math.Cos(projectile.rotation)*10;
        }
    }
    if (((Main.rand.Next(15)==0 && projectile.ai[0] > 0) || projectile.scale == 1.0) && projectile.scale > 0.4f) {
        int num54 = Projectile.NewProjectile(projectile.position.X, projectile.position.Y,0,0,"Impulse Bolt",(int)(O.inventory[O.selectedItem].damage * O.magicDamage),O.inventory[O.selectedItem].knockBack,projectile.owner);
        Main.projectile[num54].scale=projectile.scale*(Main.rand.Next(100)/100f);
	Main.projectile[num54].rotation = (P.ai[1] == 0 ? (P.rotation + (Main.rand.Next(100)-50)/100f) : P.rotation);
	P.ai[1] = P.rotation;
        //Main.projectile[num54].rotation = projectile.rotation + (Main.rand.Next(100)-50)/100f;
        Main.projectile[num54].timeLeft = projectile.timeLeft;
        Main.projectile[num54].position.X += (float)Math.Cos(projectile.rotation)*Main.projectile[num54].scale*48;
        Main.projectile[num54].position.Y += (float)Math.Sin(projectile.rotation)*Main.projectile[num54].scale*48;
        Main.projectile[num54].position.X += (float)Math.Cos(Main.projectile[num54].rotation)*Main.projectile[num54].scale*48;
        Main.projectile[num54].position.Y += (float)Math.Sin(Main.projectile[num54].rotation)*Main.projectile[num54].scale*48;
        Main.projectile[num54].ai[0]=10;
    }
    projectile.ai[0]--;
    projectile.alpha = 255-(projectile.timeLeft*2)-(int)(25*projectile.scale);
    if (projectile.alpha < 100) projectile.alpha = 0;
    //if (Main.tileSolid[Main.tile[(int)(projectile.position.X / 16f), (int)(projectile.position.Y / 16f)].type] && Main.tile[(int)(projectile.position.X / 16f), (int)(projectile.position.Y / 16f)].active)
    if (!Main.tile[(int)(projectile.position.X / 16f), (int)(projectile.position.Y / 16f)].active)
    {
	projectile.tileCollide = true;
    }
}