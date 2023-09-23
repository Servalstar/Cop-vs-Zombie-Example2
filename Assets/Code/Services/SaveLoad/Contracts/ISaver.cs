namespace Services.SaveLoad.Contracts
{
    public interface ISaver
    {
        void Save<T>(string name, T data) where T : class;
        T Load<T>(string name) where T : class;
    }
}