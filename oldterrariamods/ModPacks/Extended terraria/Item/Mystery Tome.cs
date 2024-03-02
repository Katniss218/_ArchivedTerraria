public bool PreShoot(Player P,Vector2 pos,Vector2 vel,int projType,int Damage,float kb,int owner)
{

    /*float shootSpeed= 15f;
    float speedX = ((Main.mouseX + Main.screenPosition.X) - (P.position.X + P.width * 0.5f));
    float speedY = ((Main.mouseY + Main.screenPosition.Y) - (P.position.Y + P.height * 0.5f));
    float shootFinal = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
    shootFinal = shootSpeed / shootFinal;
    speedX *= shootFinal;
    speedY *= shootFinal;*/


    int x= Main.rand.Next(9);
    if(x==0) //Starfall
    {
        Main.PlaySound(2, -1, -1, 4);
        Projectile.NewProjectile(pos.X, pos.Y, vel.X, vel.Y, 12, item.damage, 6, owner);
	return false;
    }
    else if(x==1) //Ancient
    {
        Main.PlaySound(2, -1, -1, 34);
	Projectile.NewProjectile(pos.X, pos.Y, vel.X, vel.Y, "Sandstorm", item.damage, 4, owner);
	return false;
    }
    else if(x==2) //Devil's Scythe
    {
        Main.PlaySound(2, -1, -1, 8);
	Projectile.NewProjectile(pos.X, pos.Y, vel.X, vel.Y, "Devil Sickle", item.damage, 5, owner);
	return false;
    }
    else if(x==3) //Tome of Necromancy
    {
        Main.PlaySound(2, -1, -1, 1);
	Projectile.NewProjectile(pos.X, pos.Y, vel.X, vel.Y, "Necro", item.damage, 4, owner);
	return false;
    }
    else if(x==4) //Tome of the Distant Past
    {
        Main.PlaySound(2, -1, -1, 1);
	Projectile.NewProjectile(pos.X, pos.Y, vel.X, vel.Y, "Bones", item.damage, 4, owner);
	return false;
    }
    else if(x==5) //The Blackened Flames
    {
        Main.PlaySound(2, -1, -1, 20);
	Projectile.NewProjectile(pos.X, pos.Y, vel.X, vel.Y, "Black Fire", item.damage, 6, owner);
	return false;
    }
    else if(x==6) //The Golden Flames
    {
        Main.PlaySound(2, -1, -1, 20);
	Projectile.NewProjectile(pos.X, pos.Y, vel.X, vel.Y, "Golden Fire 2", item.damage, 6, owner);
	return false;
    }
    else if(x==7) //Focus Beam
    {
        Main.PlaySound(2,-1,-1,SoundHandler.soundID["Beam"]);
	Projectile.NewProjectile(pos.X, pos.Y, vel.X, vel.Y, "Focus Beam", item.damage, 5, owner);
	return false;
    }
    else if(x==8) // Freeze Bolt
    {
        Main.PlaySound(2, -1, -1, 21);
	Projectile.NewProjectile(pos.X, pos.Y, vel.X, vel.Y, "Freeze Bolt", item.damage, 5, owner);
	return false;
    }
    return true;
}
    



