namespace Project1.Interfaces
{
    public interface ILootTable
    {
        List<IItem> common;

        List<IItem> uncommon;

        List<IItem> rare;

        List<IItem> epic;

        List<IItem> mythic;

        public IItem GetCommonItem()
        {
            /*int itemIndex = Random.Range(0, common.Count);
            return common[itemIndex];*/
        }

        public IItem GetUncommonItem()
        {
            /*int itemIndex = Random.Range(0, uncommon.Count);
            return uncommon[itemIndex];*/
        }

        public IItem GetRareItem()
        {
            /*int itemIndex = Random.Range(0, rare.Count);
            return rare[itemIndex];*/
        }

        public IItem GetEpicItem()
        {
            /*int itemIndex = Random.Range(0, epic.Count);
            return epic[itemIndex];*/
        }

        public IItem GetMythicItem()
        {
            /*int itemIndex = Random.Range(0, mythic.Count);
            return mythic[itemIndex];*/
        }

    }
}
