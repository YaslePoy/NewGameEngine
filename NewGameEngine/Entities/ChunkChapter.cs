namespace NewGameEngine;

public unsafe struct ChunkChapter
{
    public CompositeType Type;
    public ChunkChapter* NextChunk;

    public ChunkChapter(CompositeType type)
    {
        Type = type;
    }
}