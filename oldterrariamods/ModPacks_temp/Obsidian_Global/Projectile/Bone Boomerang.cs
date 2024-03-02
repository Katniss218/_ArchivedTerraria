public void DealtNPC(NPC npc, double damage, Player player) {

   Codable.globalRunKnowledge=true;
          
            player.inventory[player.selectedItem].RunMethod("DecreaseCount", 15);

            player.inventory[player.selectedItem].toolTip3 = "Durability : "+(int)Codable.customMethodReturn+"/35";

			Codable.globalRunKnowledge=false;
}

