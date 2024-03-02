public static int[] Defense_Bonus = new int[Main.player.Length];
public static bool dragoonBoots = false;
public static bool dragoonJump = false;


public void UpdatePlayer(Player P)  
{
    int ME = P.whoAmi;
    P.statDefense+=Defense_Bonus[ME];
    Defense_Bonus[ME] = 0;
    bool SearchForShields = (Main.GetKeyState((int)Microsoft.Xna.Framework.Input.Keys.C) < 0);
    if (SearchForShields && P.itemAnimation == 0)
    {
        for (int l = 0; l < 40; l++)
        {
            if (IsShield(P.inventory[l]))
            {
                if (P.nonTorch == -1)
                {
                    P.nonTorch = P.selectedItem;
                }
                P.selectedItem = l;
                break;
            }   
        }
    }
    if(SearchForShields && P.selectedItem != P.nonTorch && IsShield(P.inventory[P.selectedItem])) P.controlUseItem = true;
    if(SearchForShields && P.heldProj >= 0 && Main.projectile[P.heldProj].name.Contains("Shield")) P.controlUseItem = true;
    bool toggleDragoonBoots = (Main.GetKeyState((int)Microsoft.Xna.Framework.Input.Keys.Z) == 1);
    if (dragoonBoots)
    {
        if (toggleDragoonBoots)
        {
            dragoonJump = true;
            //Main.NewText("Dragoon Jump is now active.", 175, 75, 255);
        }
        else
        {
            dragoonJump = false;
           //Main.NewText("Dragoon Jump is now deactivated.", 175, 75, 255);
        }
    }
    else
    {
        dragoonBoots = false;
        dragoonJump = false;
        //Main.NewText("Dragoon Jump is now deactivated3.", 175, 75, 255);
    }
    dragoonBoots = false;
    if (dragoonJump)
    {
	    Player.jumpSpeed += 10f;
    }
}

public bool IsShield(Item I)
{
    if(I.shoot == 0) return false;
    if(I.RunMethod("This_Is_A_Shield")) return true;
    return false;
}