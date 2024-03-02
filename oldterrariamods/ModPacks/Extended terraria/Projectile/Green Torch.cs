public void Kill()
{
    int TileX = (int)(projectile.position.X + projectile.width * 0.5f) / 16;
    int TileY = (int)(projectile.position.Y + projectile.height * 0.5f) / 16;
 
    if (TileX < 0 || TileX >= Main.maxTilesX || TileY < 0 || TileY >= Main.maxTilesY)
    {
        projectile.active = false;
        return;
    }
 
    if (!Main.tile[TileX, TileY].active)
    {
        WorldGen.PlaceTile(TileX, TileY, 4, false, true, -1, 0);
        // not sure if PlaceTile calls TileFrame
        WorldGen.TileFrame(TileX, TileY);
        Main.tile[TileX, TileY].frameY = 66;
        projectile.active = false;
    }
    else 
    {
        Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, 16, 16, 429);
        projectile.active = false;
        return;
    }

    if (!Main.tile[TileX, TileY].active && (Main.tile[TileX + 1, TileY + 1].active || Main.tile[TileX - 1, TileY + 1].active || Main.tile[TileX + 1, TileY - 1].active || Main.tile[TileX - 1, TileY - 1].active) && !Main.tile[TileX, TileY + 1].active)
    {
        Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, 16, 16, 429);
        projectile.active = false;
    }

    if (Main.tile[TileX, TileY].liquid > 0)
    {
        Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, 16, 16, 429);
        projectile.active = false;
    }
 
    // if that doesn't work, there is also SquareTileFrame
    //WorldGen.SquareTileFrame(TileX, TileY);
 
    projectile.active = false;
}