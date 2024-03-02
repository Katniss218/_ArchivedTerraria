
public void UseStyle(Player player)
{
float backX = 24f; // move the weapon back
float downY = 0f; // and down
float cosRot = (float)Math.Cos(player.itemRotation);
float sinRot = (float)Math.Sin(player.itemRotation);
//Align
player.itemLocation.X = player.itemLocation.X - (backX * cosRot * player.direction) - (downY * sinRot * player.gravDir);
player.itemLocation.Y = player.itemLocation.Y - (backX * sinRot * player.direction) + (downY * cosRot * player.gravDir);
}

public bool PreShoot(Player P,Vector2 Pos,Vector2 Velo,int type,int DMG,float KB,int owner)
{//as usual, ty Yoraiz0r
    if(type==14){type = Config.projDefs.byName["Anti Material Round"].type;}
    Projectile.NewProjectile(Pos.X,Pos.Y,Velo.X,Velo.Y,type,DMG,KB,owner);
    return false;
}