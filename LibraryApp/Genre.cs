using System;

namespace LibraryApp
{
    [Flags]
    public enum Genre
    {
        Fiction = 1,
        Thriller = 2,
        Fantasy = 4,
        Horror = 8,
        Contemporary = 16,
        Detective = 32,
        ScienceFiction = 64,
        Bildungsroman = 128,
        Crime = 256,
        Technical = 512,
        Philosophical = 1024,
        Alternative = 2048,
        Economic = 4096,
        Sciense = 8192,
        Auto = 16384,
        Politic = 32768,
        Electronic = 65536,
        Fashion = 131072,
        Nature = 262144,
        News = 524288,
        Jurisprudence = 1048576
    }
}
