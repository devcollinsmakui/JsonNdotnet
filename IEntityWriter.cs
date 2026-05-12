interface IEntityWriter<T>
{
    Task Save(T Entity);
}