public bool CanUse(Player Pr,int PID)
{
    int limit = 10;

    int counter = 0;
    int target = Config.projDefs.byName["Forgotten Rising Sun"].type;
    foreach (Projectile P in Main.projectile)
    {
         if(P.active && P.owner == PID && P.type == target) counter++;
    }
    return counter<limit;
}