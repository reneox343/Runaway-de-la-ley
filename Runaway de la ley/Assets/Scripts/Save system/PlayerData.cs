[System.Serializable]
public class PlayerData
{
    public int level;
    public int money;
    public bool[] astiModeUpgrades = new bool[4];
    public bool[] revolversUpgrades = new bool[4];
    public bool[] shootgunUpgrades = new bool[4];
    public bool[] trowablesUpgrades = new bool[4];

    public PlayerData(int level,int money, bool[] revolverUpgrades, bool[] revolversUpgrades, bool[] shootgunUpgrades, bool[] trowablesUpgrades) {
        this.level = level;
        this.money = money;
        this.astiModeUpgrades = revolverUpgrades;
        this.revolversUpgrades = revolversUpgrades;
        this.shootgunUpgrades = shootgunUpgrades;
        this.trowablesUpgrades = trowablesUpgrades;

    }

}
