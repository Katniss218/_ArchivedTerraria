#region egg drops , enchantments
public void NPCLoot()
{
#region eggdrops
 if (npc.life <= 0)
    {
        if(npc.type == Config.npcDefs.byName["Mechanical Phoenix"].type)
        {
            int drop1 = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Config.itemDefs.byName["Phoenix Helmet"].type, 1, false, 0);
            int drop2 = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Config.itemDefs.byName["Heavenly Ore Spawner"].type, 1, false, 0);
                Main.item[drop1].stack = 1;
                Main.item[drop2].stack = 1;
                    if (Main.netMode == 1)
                        NetMessage.SendData(21, -1, -1, "", drop1, 0f, 0f, 0f, 0);
                        NetMessage.SendData(21, -1, -1, "", drop2, 0f, 0f, 0f, 0);
        }
        if(npc.type == Config.npcDefs.byName["Mechanical Jungix"].type)
        {
            int drop1 = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Config.itemDefs.byName["Phoenix Armor"].type, 1, false, 0);
            int drop2 = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Config.itemDefs.byName["Hallowed Ore"].type, 1, false, 0);
                Main.item[drop1].stack = 1;
                Main.item[drop2].stack = 15;
                    if (Main.netMode == 1)
                        NetMessage.SendData(21, -1, -1, "", drop1, 0f, 0f, 0f, 0);
                        NetMessage.SendData(21, -1, -1, "", drop2, 0f, 0f, 0f, 0);
        }
        if(npc.type == Config.npcDefs.byName["Mechanical Aquatix"].type)
        {
            int drop1 = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Config.itemDefs.byName["Phoenix Greaves"].type, 1, false, 0);
            int drop2 = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Config.itemDefs.byName["Mechanical Parts"].type, 1, false, 0);
                    if (Main.netMode == 1)
                        NetMessage.SendData(21, -1, -1, "", drop1, 0f, 0f, 0f, 0);
                        NetMessage.SendData(21, -1, -1, "", drop2, 0f, 0f, 0f, 0);
        }
        if(npc.type == Config.npcDefs.byName["Dungeon Guardian"].type)
        {
            int drop1 = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Config.itemDefs.byName["Guardian Sword"].type, 1, false, 0);
                    if (Main.netMode == 1)
                        NetMessage.SendData(21, -1, -1, "", drop1, 0f, 0f, 0f, 0);
        }
        if(npc.type == Config.npcDefs.byName["Hornet"].type)
        {
            int drop1 = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Config.itemDefs.byName["Grassy Egg"].type, 1, false, 0);
                    if (Main.netMode == 1)
                        NetMessage.SendData(21, -1, -1, "", drop1, 0f, 0f, 0f, 0);
        }
        if(npc.type == Config.npcDefs.byName["Shark"].type)
        {
            int drop1 = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Config.itemDefs.byName["Watery Egg"].type, 1, false, 0);
                    if (Main.netMode == 1)
                        NetMessage.SendData(21, -1, -1, "", drop1, 0f, 0f, 0f, 0);
        }
        if(npc.type == Config.npcDefs.byName["Fire Imp"].type)
        {
            int drop1 = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Config.itemDefs.byName["Fiery Egg"].type, 1, false, 0);
                    if (Main.netMode == 1)
                        NetMessage.SendData(21, -1, -1, "", drop1, 0f, 0f, 0f, 0);
        }
        if(npc.type == Config.npcDefs.byName["Phoenix"].type)
        {
            int drop1 = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Config.itemDefs.byName["Crest of Fire"].type, 1, false, 0);
            int drop2 = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Config.itemDefs.byName["Light Cube"].type, 1, false, 0);
            int drop3 = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Config.itemDefs.byName["Token of Time"].type, 1, false, 0);
                Main.item[drop1].stack = 1;
                Main.item[drop2].stack = 1;
                Main.item[drop3].stack = 1;
                    if (Main.netMode == 1)
                        NetMessage.SendData(21, -1, -1, "", drop1, 0f, 0f, 0f, 0);
                        NetMessage.SendData(21, -1, -1, "", drop2, 0f, 0f, 0f, 0);
                        NetMessage.SendData(21, -1, -1, "", drop3, 0f, 0f, 0f, 0);
        }
        if(npc.type == Config.npcDefs.byName["Jungix"].type)
        {
            int drop1 = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Config.itemDefs.byName["Crest of Earth"].type, 1, false, 0);
            int drop2 = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Config.itemDefs.byName["Clobber Hand"].type, 1, false, 0);
            int drop3 = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Config.itemDefs.byName["Token of Time"].type, 1, false, 0);
                Main.item[drop1].stack = 1;
                Main.item[drop2].stack = 1;
                Main.item[drop3].stack = 1;
                    if (Main.netMode == 1)
                        NetMessage.SendData(21, -1, -1, "", drop1, 0f, 0f, 0f, 0);
                        NetMessage.SendData(21, -1, -1, "", drop2, 0f, 0f, 0f, 0);
                        NetMessage.SendData(21, -1, -1, "", drop3, 0f, 0f, 0f, 0);
        }
        if(npc.type == Config.npcDefs.byName["Aquatix"].type)
        {
            int drop1 = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Config.itemDefs.byName["Crest of Water"].type, 1, false, 0);
            int drop2 = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Config.itemDefs.byName["Floater Shoes"].type, 1, false, 0);
            int drop3 = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Config.itemDefs.byName["Token of Time"].type, 1, false, 0);
                Main.item[drop1].stack = 1;
                Main.item[drop2].stack = 1;
                Main.item[drop3].stack = 1;
                    if (Main.netMode == 1)
                        NetMessage.SendData(21, -1, -1, "", drop1, 0f, 0f, 0f, 0);
                        NetMessage.SendData(21, -1, -1, "", drop2, 0f, 0f, 0f, 0);
                        NetMessage.SendData(21, -1, -1, "", drop3, 0f, 0f, 0f, 0);
        }
        if(npc.type == Config.npcDefs.byName["Skeletron"].type)
        {
            int drop1 = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Config.itemDefs.byName["Heely Wheelies"].type, 1, false, 0);
                    if (Main.netMode == 1)
                        NetMessage.SendData(21, -1, -1, "", drop1, 0f, 0f, 0f, 0);
        }
    }

#endregion
}
#endregion