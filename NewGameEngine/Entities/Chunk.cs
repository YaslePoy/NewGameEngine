namespace NewGameEngine;

public struct Chunk
{
    private ChunkChapter _startChapter;
    public readonly CompositeType StoreType;

    public Chunk(CompositeType storeType)
    {
        StoreType = storeType;
        _startChapter = new ChunkChapter(storeType);
    }
}