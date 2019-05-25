namespace AllaBolag.BL.Builders
{
    public interface IBuildStrategy<T>
    {
        T Build();
    }
}