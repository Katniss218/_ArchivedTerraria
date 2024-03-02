//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public bool UseAmmo(Player P) 
{
    if (Main.rand.Next(4) == 0)
    {
        return true;
    }
    else 
    {
      return false;
    }
    return true;
}
