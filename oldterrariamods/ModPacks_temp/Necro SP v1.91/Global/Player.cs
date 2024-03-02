public static string associatedWorld = "";
public static string currentWorld = "Normal";
public static string NormalWorldName = "";
public static bool diamondUse = false;
public static bool hasPet = false;
public static NPC pet = null;
public int m = 0;

#region Has pet
public void Load(BinaryReader reader)
{
    associatedWorld=reader.ReadString();
    NormalWorldName=reader.ReadString();
    hasPet = false;
    pet = null;
}
#endregion

#region World Name
public void Save(BinaryWriter writer)
{
    writer.Write(associatedWorld);
    writer.Write(NormalWorldName);
}
#endregion

#region Starting Weapon
public void CreatePlayer(Player player)
{
    player.inventory[0].SetDefaults(Config.itemDefs.byName["Ghoul Sword"].type);
    player.inventory[0].stack = 1;
}
#endregion

