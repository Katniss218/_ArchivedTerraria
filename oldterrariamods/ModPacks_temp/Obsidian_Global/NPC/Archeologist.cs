
public static string ChatFuncName() {
	return "Repair";
}
public void ChatFunc() {
	RepairInterface.Create();
	Main.npcChatText = "";
	Main.playerInventory = true;
	}

public class RepairInterface : Interfaceable {
	int upgradeCost=0;
 


	public static void Create() {
		Config.npcInterface = new InterfaceObj(new RepairInterface(), 3, 3);
		Config.npcInterface.AddItemSlot(150,250);
		Config.npcInterface.AddItemSlot(230,250);
		Config.npcInterface.AddText("Repair :", 130, 230, false, 0.9f);
		Config.npcInterface.AddText("Bone :", 225, 230, false, 0.9f);
        Config.npcInterface.AddText("Repair Item !", 140, 310,  true ,1.2f);
	}


    public void ButtonClicked(int button) {

        Item[] itemSlots = Config.npcInterface.itemSlots;
    if(itemSlots[0] != null && itemSlots[1].name == "Prehistoric Bone") {

            Codable.globalRunKnowledge=true;
            itemSlots[0].RunMethod("Repair", itemSlots[1].stack);
            itemSlots[1].stack-= (int) Codable.customMethodReturn;
            Main.NewText(""+(int) Codable.customMethodReturn);
			Codable.globalRunKnowledge=false;


        if(itemSlots[1].stack==0) {
            itemSlots[1]=new Item();
        }

        DropSlot(0);
        
    }

    }

	public bool CanPlaceSlot(int slot, Item mouseItem) {
		if(slot==2) {
			if(mouseItem.type==0 || mouseItem.stack==0) return true;
			else return false;
			}
		return true;
	}

	public void PlaceSlot(int slot) {


		}


 
	

	public bool DropSlot(int slot) {
		if(slot==2) return false;
		return true;
	}
}

public static string SetName() {
	if(Main.rand.Next(2)==0)
		return "Dr Jones";
	
	return "Denver";
}

public static bool TownSpawn() {
if(ModPlayer.parallelVisit == true){
return true;
}
return false;
}

public static string Chat() {
	if(Main.rand.Next(2)==0)
		return "Do you like fresh meat ?";
	return "Bring me dino bones and i'll repair your stuff !";
}
