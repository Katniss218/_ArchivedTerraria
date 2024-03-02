
//Methods

public void PreDrawInterface(SpriteBatch spritebatch) {
	Vector2 target = new Vector2(ModPlayer.crosshairX - Main.screenPosition.X,ModPlayer.crosshairY - Main.screenPosition.Y);
	if(target.X > -63 || target.X < Main.screenWidth ||
	   target.Y > -63 || target.Y < Main.screenHeight) {
		spritebatch.Draw(Main.goreTexture[Config.goreID["Gunslinger Crosshair"]], target, Color.White);
	}
}

//Mod Settings

public int GetSettingCount() {
	return 1;
}

public string GetSettingName(int setting) {
	return "Draw Auras";
}

public object GetSettingValue(int setting) {
	return ModPlayer.drawAuras;
}

public object SetSettingValue(int setting, object value) {
	return (ModPlayer.drawAuras = (bool)value);
}
