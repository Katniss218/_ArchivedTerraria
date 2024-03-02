
public const Microsoft.Xna.Framework.Input.Keys DisplayKey = Microsoft.Xna.Framework.Input.Keys.F3;
public const Microsoft.Xna.Framework.Input.Keys FilterKey = Microsoft.Xna.Framework.Input.Keys.LeftShift;
public const Microsoft.Xna.Framework.Input.Keys FilterKey2 = Microsoft.Xna.Framework.Input.Keys.RightShift;

public const bool can_cheat = false;

public static void OnLoad() {
	ModWorld.LoadTextures();
}

public static void OnRecipeRefresh() {
	ModWorld.inside_findrecipes = true;
	ModWorld.RefreshAvailableMode();
	ModWorld.inside_findrecipes = false;
}