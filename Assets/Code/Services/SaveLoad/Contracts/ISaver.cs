namespace Services.SaveLoad.Contracts
{
    public interface ISaver
    {
        void Save<T>(T data) where T : class;
        T Load<T>() where T : class, new();
    }
}