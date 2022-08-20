namespace Todo.Domain.Entities;

public abstract class BaseEntity : IEquatable<BaseEntity>
{
    #region Constructor

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
    }

    #endregion

    #region Properties

    public Guid Id { get; }

    #endregion

    #region Methods

    public bool Equals(BaseEntity? other)
    {
        return Id == other?.Id;
    }

    #endregion
}